import "./style.css";
import { onAuthStateChanged, signInWithPopup, signOut } from "firebase/auth";
import { doc, getDoc } from "firebase/firestore";
import { auth, db, googleProvider, ADMIN_EMAIL } from "./firebase.js";

const loginButton = document.querySelector("#google-login");
const logoutButton = document.querySelector("#logout");
const message = document.querySelector("#auth-message");
const accountPanel = document.querySelector("#account-panel");
const welcome = document.querySelector("#welcome");
const roleContent = document.querySelector("#role-content");

loginButton.addEventListener("click", async () => {
  message.textContent = "Abriendo acceso de Google…";
  loginButton.disabled = true;
  try {
    await signInWithPopup(auth, googleProvider);
  } catch (error) {
    console.error(error);
    message.textContent = friendlyAuthError(error);
  } finally {
    loginButton.disabled = false;
  }
});

logoutButton.addEventListener("click", () => signOut(auth));

onAuthStateChanged(auth, async (user) => {
  if (!user) {
    accountPanel.classList.add("hidden");
    loginButton.classList.remove("hidden");
    message.textContent = "Inicia sesión para continuar.";
    return;
  }

  loginButton.classList.add("hidden");
  accountPanel.classList.remove("hidden");
  welcome.textContent = `Hola, ${user.displayName || user.email}`;
  message.textContent = "";

  const isAdmin = user.email?.toLowerCase() === ADMIN_EMAIL;
  if (isAdmin) {
    roleContent.innerHTML = `
      <div class="notice success"><strong>Acceso administrativo reconocido.</strong>
      <span>Esta cuenta está configurada como administradora principal.</span></div>
      <div class="metrics">
        <article><small>Moneda</small><strong>USD ($)</strong></article>
        <article><small>Frecuencia</small><strong>Mensual</strong></article>
        <article><small>Métodos</small><strong>Transferencia / efectivo</strong></article>
      </div>
      <p class="muted">Siguiente etapa: habilitar alta de clientes, generación de cuotas, recibos y aprobación de reportes de pago.</p>`;
    return;
  }

  try {
    const profile = await getDoc(doc(db, "users", user.uid));
    if (!profile.exists() || profile.data().active !== true || !profile.data().clientId) {
      roleContent.innerHTML = `<div class="notice warning"><strong>Cuenta pendiente de vinculación.</strong><span>Solicita al administrador que habilite tu acceso al portal ENTERPRICE.</span></div>`;
      return;
    }
    roleContent.innerHTML = `<div class="notice success"><strong>Acceso de cliente habilitado.</strong><span>Tu cuenta está vinculada. El portal de recibos se habilitará en la siguiente etapa.</span></div>`;
  } catch (error) {
    console.error(error);
    roleContent.textContent = "No se pudo consultar tu perfil. Verifica la conexión y las reglas de Firebase.";
  }
});

function friendlyAuthError(error) {
  const messages = {
    "auth/popup-closed-by-user": "Se cerró la ventana de Google antes de completar el acceso.",
    "auth/popup-blocked": "El navegador bloqueó la ventana. Permite las ventanas emergentes e inténtalo de nuevo.",
    "auth/unauthorized-domain": "Este dominio aún no está autorizado en Firebase Authentication."
  };
  return messages[error.code] || `No se pudo iniciar sesión (${error.code || "error desconocido"}).`;
}
