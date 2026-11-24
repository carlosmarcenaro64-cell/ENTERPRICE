# ENTERPRICE — herramientas de eliminación administrativa

Los botones de borrado se muestran únicamente en las vistas administrativas y requieren confirmación explícita.

## Recibos
- Botón **Borrar** en cada recibo.
- Antes de confirmar, se informa que también se borrarán los abonos y reportes asociados al recibo.
- La eliminación se ejecuta en lotes de Firestore para respetar el límite de operaciones por lote.

## Abonos
- Botón **Borrar abono** en el historial de pagos.
- La operación elimina el movimiento y revierte su importe del campo `paidAmount` del recibo asociado.
- El estado del recibo se recalcula: `pending`, `partial` o `paid`.
- Si el abono provenía de un reporte aprobado, ese reporte vuelve a estado `pending` para que pueda revisarse nuevamente.

## Reportes de pago
- Se muestra el historial completo de reportes, no solo los pendientes.
- El administrador puede borrar reportes pendientes, rechazados o aprobados.
- Borrar un reporte aprobado **no borra el abono contabilizado**. Para revertir también el saldo, primero se debe borrar el abono desde **Pagos y abonos**.

## Seguridad
- La interfaz verifica el rol administrativo antes de ejecutar estas acciones.
- `firestore.rules` ya restringe `delete` en `recibos` y `pagos`, y `delete/update` en `payment_reports` a los dos correos administradores autorizados.
- La autorización real la aplica Firestore; ocultar botones en el navegador no sustituye las reglas.

## Antes de usar en producción
1. Realiza una copia de seguridad de Firestore.
2. Prueba con recibos y abonos de prueba.
3. Verifica ambos administradores.
4. No borres recibos históricos reales sin confirmar primero el efecto en sus abonos y reportes asociados.
