# API de Gestión de Clientes y Facturas

## Descripción

Esta API proporciona funcionalidades para la gestión y validación de datos de clientes y facturas, asegurando que la información proporcionada cumpla con ciertos criterios de formato y obligatoriedad.

## Tabla de Contenidos

- [Uso](#uso)
- [Endpoints](#endpoints)
  - [Clientes](#clientes)
    - [Agregar Cliente](#agregar-cliente)
    - [Actualizar Cliente](#actualizar-cliente)
    - [Eliminar Cliente](#eliminar-cliente)
    - [Obtener Cliente](#obtener-cliente)
    - [Listar Clientes](#listar-clientes)
  - [Facturas](#facturas)
    - [Agregar Factura](#agregar-factura)
    - [Actualizar Factura](#actualizar-factura)
    - [Eliminar Factura](#eliminar-factura)
    - [Obtener Factura](#obtener-factura)
    - [Listar Facturas](#listar-facturas)
- [Capturas de Pantalla](#capturas-de-pantalla)
  - [Clientes](#clientes-1)
    - [Respuesta 200](#respuesta-200)
    - [Respuesta 400](#respuesta-400)
  - [Facturas](#facturas-1)
    - [Respuesta 200](#respuesta-200-1)
    - [Respuesta 400](#respuesta-400-1)
- [Manejo de Errores](#manejo-de-errores)

## Uso

La API cuenta con varios endpoints para la gestión de clientes y facturas. A continuación, se detallan los endpoints disponibles y cómo utilizarlos.

## Endpoints

### Clientes

#### Agregar Cliente

- `POST /Cliente/add`
  - **Descripción**: Inserta el registro de un cliente.
  - **Parámetros**: 
    - `id`: Integer.
    - `idBanco`: Integer.
    - `nombre`: String, mínimo 3 caracteres.
    - `apellido`: String, mínimo 3 caracteres.
    - `celular`: String, exactamente 10 caracteres numéricos.
    - `documento`: String, mínimo 7 caracteres, único.
    - `email`: String, formato de correo electrónico.
    - `estado`: String.
  - **Respuestas**:
    - **200**: Inserción exitosa.
    - **400**: Error de validación.
    - **500**: Error del servidor.

#### Actualizar Cliente

- `PUT /Cliente/update`
  - **Descripción**: Actualiza el registro de un cliente.
  - **Parámetros**: 
    - `id`: Integer.
    - `idBanco`: Integer.
    - `nombre`: String, mínimo 3 caracteres.
    - `apellido`: String, mínimo 3 caracteres.
    - `celular`: String, exactamente 10 caracteres numéricos.
    - `documento`: String, mínimo 7 caracteres, único.
    - `email`: String, formato de correo electrónico.
    - `estado`: String.
  - **Respuestas**:
    - **200**: Actualización exitosa.
    - **400**: Error de validación.
    - **500**: Error del servidor.

#### Eliminar Cliente

- `DELETE /Cliente/delete/{id}`
  - **Descripción**: Elimina un cliente existente por su ID.
  - **Parámetros**: 
    - `id`: ID del cliente a eliminar.
  - **Respuestas**:
    - **200**: Cliente eliminado exitosamente.
    - **400**: Error de validación.
    - **500**: Error del servidor.

#### Obtener Cliente

- `GET /Cliente/get/{id}`
  - **Descripción**: Obtiene la información de un cliente por su ID.
  - **Parámetros**: 
    - `id`: ID del cliente a obtener.
  - **Respuestas**:
    - **200**: Cliente obtenido exitosamente.
    - **400**: Error de validación.
    - **404**: Cliente no encontrado.
    - **500**: Error del servidor.

#### Listar Clientes

- `GET /Cliente/list`
  - **Descripción**: Obtiene una lista de todos los clientes.
  - **Parámetros**: Ninguno.
  - **Respuestas**:
    - **200**: Lista de clientes obtenida exitosamente.
    - **500**: Error del servidor.

### Facturas

#### Agregar Factura

- `POST /Factura/add`
  - **Descripción**: Agrega una nueva factura.
  - **Parámetros**: 
    - `id`: Integer. Identificador único.
    - `idCliente`: Integer. Id del cliente relacionado.
    - `nroFactura`: String. Número de la factura.
    - `fechaHora`: DateTime. Fecha y hora de la factura.
    - `total`: Double. Monto total de la factura.
    - `totalIvaCinco`: Double. Total IVA 5%.
    - `totalIvaDiez`: Double. Total IVA 10%.
    - `totalIva`: Double. Total IVA.
    - `totalLetras`: String. Total en letras.
    - `sucursal`: Integer. Sucursal relacionada.
  - **Respuestas**:
    - **200**: Factura agregada correctamente.
    - **400**: Error de validación o el cliente no existe.
    - **500**: Error del servidor.

#### Actualizar Factura

- `PUT /Factura/update`
  - **Descripción**: Actualiza una factura existente.
  - **Parámetros**: 
    - `id`: Integer. Identificador único.
    - `idCliente`: Integer. Id del cliente relacionado.
    - `nroFactura`: String. Número de la factura.
    - `fechaHora`: DateTime. Fecha y hora de la factura.
    - `total`: Double. Monto total de la factura.
    - `totalIvaCinco`: Double. Total IVA 5%.
    - `totalIvaDiez`: Double. Total IVA 10%.
    - `totalIva`: Double. Total IVA.
    - `totalLetras`: String. Total en letras.
    - `sucursal`: Integer. Sucursal relacionada.
  - **Respuestas**:
    - **200**: Factura actualizada correctamente.
    - **400**: Error de validación o el cliente no existe.
    - **500**: Error del servidor.

#### Eliminar Factura

- `DELETE /Factura/delete/{id}`
  - **Descripción**: Elimina una factura existente por su ID.
  - **Parámetros**: 
    - `id`: ID de la factura a eliminar.
  - **Respuestas**:
    - **200**: Factura eliminada correctamente.
    - **400**: Error al eliminar la factura.
    - **500**: Error del servidor.

#### Obtener Factura

- `GET /Factura/get/{id}`
  - **Descripción**: Obtiene la información de una factura por su ID.
  - **Parámetros**: 
    - `id`: ID de la factura a obtener.
  - **Respuestas**:
    - **200**: Factura obtenida exitosamente.
    - **404**: Factura no encontrada.
    - **500**: Error del servidor.

#### Listar Facturas

- `GET /Factura/list`
  - **Descripción**: Obtiene una lista de todas las facturas.
  - **Parámetros**: Ninguno.
  - **Respuestas**:
    - **200**: Lista de facturas obtenida exitosamente.
    - **204**: No hay contenido para mostrar.
    - **500**: Error del servidor.

## Capturas de Pantalla

### Clientes

#### Respuesta 200

Aquí se muestra una captura de pantalla de una respuesta exitosa.

![image](https://github.com/scaballero02/api.optativov.tareas/assets/131833552/195e4444-c2e7-48f0-8685-5f88992bb19f)

![image](https://github.com/scaballero02/api.optativov.tareas/assets/131833552/1db63c13-f433-4bee-839a-8e67e3fb3af2)

![image](https://github.com/scaballero02/api.optativov.tareas/assets/131833552/19236775-4c35-4122-a6ac-909d704917c9)

### Respuesta 400

Aquí se muestra una captura de pantalla de un error de validación.

![image](https://github.com/scaballero02/api.optativov.tareas/assets/131833552/28f222f5-135b-4542-9831-cf2ba0c650e7)

![image](https://github.com/scaballero02/api.optativov.tareas/assets/131833552/ae2b86e0-b87f-4aca-a990-239e9de56694)

![image](https://github.com/scaballero02/api.optativov.tareas/assets/131833552/b231eb22-1bad-4d79-a606-9c2bf6b2970b)

![image](https://github.com/scaballero02/api.optativov.tareas/assets/131833552/c72bf77e-e95a-40f7-b172-2989186cf4d4)

### Facturas

#### Respuesta 200

Aquí se muestra una captura de pantalla de una respuesta exitosa.

![image](https://github.com/scaballero02/api.optativov.tareas/assets/131833552/157aaeda-43b8-438e-b972-3a444a322ce4)

![image](https://github.com/scaballero02/api.optativov.tareas/assets/131833552/1b9aace4-5360-4263-ad3f-9d488309cd11)

![image](https://github.com/scaballero02/api.optativov.tareas/assets/131833552/fb77c286-2bfc-4604-ae7c-04db7629c7ce)

#### Respuesta 400

Aquí se muestra una captura de pantalla de un error de validación.

![image](https://github.com/scaballero02/api.optativov.tareas/assets/131833552/6e6799a2-fc88-4618-a928-2605d2220b41)

![image](https://github.com/scaballero02/api.optativov.tareas/assets/131833552/411c227f-739d-489a-9076-f649cef5267f)


## Manejo de Errores

La API maneja diferentes tipos de errores y proporciona respuestas claras para cada uno:

- **200 OK**: La solicitud se procesó correctamente.
- **204 No Content**: La solicitud se procesó pero no retornó ningún resultado.
- **400 Bad Request**: Hubo un error en la validación de los datos proporcionados.
- **404 Not Found**: El cliente o la factura no fueron encontrados.
- **500 Internal Server Error**: Ocurrió un error inesperado en el servidor.
