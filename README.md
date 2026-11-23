# ENTERPRICE — starter Firebase

Base inicial de ENTERPRICE: Vite + JavaScript + Firebase Authentication, Cloud Firestore y Storage.

## Configuración inicial

1. Crea un proyecto en Firebase Console.
2. Registra una aplicación web y copia sus credenciales.
3. En Authentication habilita Google como proveedor.
4. En Authentication > Settings > Authorized domains agrega el dominio donde publicarás la web (y localhost para desarrollo).
5. Crea Cloud Firestore en modo producción y Firebase Storage.
6. Copia `.env.example` como `.env.local` y completa las variables `VITE_FIREBASE_*`.
7. Revisa y publica `firestore.rules` y `storage.rules` desde Firebase Console.
8. Instala y ejecuta:

   ```bash
   npm install
   npm run dev
   ```

9. Para producción: `npm run build`; publica la carpeta `dist` en Firebase Hosting, Vercel o Netlify.

## Cuenta administradora inicial

El correo configurado como administrador es `carlosmarcenaro64@gmail.com`. Debe iniciar sesión con Google y tener el correo verificado. La regla de administrador está restringida a ese correo. Para cambiarlo, actualiza `VITE_ADMIN_EMAIL` y también el correo literal en `firestore.rules` y `storage.rules`, y vuelve a publicar las reglas.

## Modelo de datos previsto

- `users/{uid}`: `{ role: "client", clientId: "...", active: true }`
- `clients/{clientId}`: datos de cliente, estado y contacto.
- `cuotas/{cuotaId}`: `{ clientId, amount, dueDate, status, period }`
- `recibos/{reciboId}`: número, cliente, concepto, total y estado.
- `pagos/{pagoId}`: pagos verificados y aplicados.
- `payment_reports/{reportId}`: reportes enviados por clientes; inician con `status: "pending"`.
- `settings/company`: nombre, moneda USD, frecuencia mensual y métodos permitidos.

## Importante antes de producción

Esta es una base de arranque, no la aplicación terminada. Aún falta implementar los formularios CRUD, asignación de clientes, generación de PDF, envío por WhatsApp, aprobación transaccional de pagos, validaciones de importes y vencimientos, auditoría desde backend y pruebas de reglas.

Las reglas son un primer control de acceso. Para producción se recomienda mover la autorización administrativa a Firebase custom claims gestionados desde un entorno confiable, implementar Cloud Functions para aprobar/aplicar pagos y generar recibos, y probar reglas con Firebase Emulator Suite. Nunca coloques claves privadas de Admin SDK en el frontend.
