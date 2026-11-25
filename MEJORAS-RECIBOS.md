# ENTERPRICE – Recibos empresariales

## Cambios incluidos
- Nuevo diseñador de recibos con múltiples líneas de productos y servicios.
- Campos por línea: descripción, cantidad, precio unitario y descuento opcional en dólares.
- Cálculo automático de importe por línea, subtotal, descuentos, impuesto porcentual, envío, otros cargos y total.
- Validación de cantidades, precios, descuentos y total antes de emitir.
- Conserva el campo `amount` como total final para mantener compatibilidad con saldos, pagos, reportes y recibos ya existentes.
- Guarda el desglose en `items`, `subtotal`, `discount`, `taxRate`, `taxAmount`, `shipping` y `otherCharges`.
- Impresión/PDF rediseñada con cabecera empresarial, datos del cliente, desglose y resumen financiero.
- Datos de empresa configurables en Configuración y guardados en `settings/company`.
- Compatibilidad de impresión con recibos antiguos que no tienen arreglo `items`.

## Despliegue y pruebas necesarias
1. Respaldar Firestore antes de publicar.
2. Reemplazar los archivos del proyecto por esta versión.
3. No es necesario cambiar las reglas actuales para los nuevos campos del recibo; las escrituras de recibos siguen reservadas a administradores y `settings` ya permite escritura administrativa.
4. Probar con un recibo de varias líneas, uno con descuento cero y otro con descuento e impuesto.
5. Verificar el PDF, el saldo del cliente, registrar un abono, aprobar un reporte de pago y probar el portal de cliente.

La sintaxis del módulo JavaScript fue validada con Node.js. Las operaciones reales de Firebase y la impresión deben probarse en el proyecto desplegado.
