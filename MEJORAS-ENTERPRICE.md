# ENTERPRICE — actualización visual y funcional

## Cambios incluidos
- Renovación visual responsive con tarjetas, paneles, tablas y navegación más pulidos.
- Microanimaciones de entrada, hover y estados de botones; respeta `prefers-reduced-motion`.
- Dashboard con botón de actualización manual.
- Exportación CSV de clientes, recibos y saldos.
- Portal del cliente con resumen de cuenta y acciones para imprimir/compartir recibos por WhatsApp.
- Fecha local del navegador para evitar desfases de un día por conversión UTC.
- Ambos administradores se mantienen reconocidos en el módulo inicial y en las reglas de Storage.
- Reglas de Firestore reforzadas: un cliente desactivado pierde acceso a sus datos y los reportes de pago deben corresponder a un recibo propio y no superar el saldo pendiente.

## Antes de publicar
1. Haz una copia de seguridad del proyecto y de Firestore.
2. Publica `firestore.rules` desde Firebase Console → Firestore Database → Rules.
3. Publica `storage.rules` desde Firebase Console → Storage → Rules.
4. Prueba el acceso con ambos administradores y con una cuenta de cliente activa y otra desactivada.
5. Verifica que un cliente solo vea sus recibos y que no pueda reportar un importe superior al saldo.

## Importante
- No se modificó el proyecto Firebase ni se migraron colecciones.
- Los administradores siguen siendo `carlosmarcenaro64@gmail.com` y `carlosmarcenaro2@gmail.com`.
- No se agregó eliminación física de recibos o pagos para conservar trazabilidad financiera.
- Las credenciales de configuración web de Firebase no sustituyen las reglas de seguridad; mantén las reglas publicadas y prueba los permisos.
