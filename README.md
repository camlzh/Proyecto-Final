# Proyecto-Final
<div align="center">

#  PROYECTO FINAL: UNIDAD 3
#  SISTEMA DE RESERVAS DE HOTEL

[![C#](https://img.shields.io/badge/Language-C%23-blue.svg)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Framework](https://img.shields.io/badge/Framework-.NET-purple.svg)](https://dotnet.microsoft.com/)

</div>

---

##  1. Descripción General
Este software es una solución de consola para la gestión de reservas hoteleras. Ha sido refactorizado para cumplir con una **arquitectura modular**, separando las responsabilidades de interfaz, lógica de cálculo y control de flujo.

---

##  2. Arquitectura de Funciones
Siguiendo los requisitos de la rúbrica, el sistema se ha dividido en funciones con **Responsabilidad Única**.

###  Tabla de Funciones y Jerarquía

| Función | Tipo | Responsabilidad | Parámetros / Retorno |
| :--- | :--- | :--- | :--- |
| `EjecutarSistemaReservas` | **Orquestación** | Coordina el ciclo de vida del programa y el menú principal. | N/A |
| `ProcesarReserva` | **Orquestación** | Une la captura de datos con la lógica y la salida. | `string tipo`, `double precio` |
| `CalcularSubtotal` | **Lógica** | Realiza el cálculo base (Precio * Noches). | `double`, `int` -> `double` |
| `CalcularDescuento` | **Lógica** | Aplica el 15% de descuento si noches >= 5. | `double`, `int` -> `double` |
| `CalcularImpuesto` | **Lógica** | Calcula el 10% de impuesto hotelero. | `double` -> `double` |
| `LeerOpcion` | **UI / Entrada** | Captura y valida la opción del menú. | `int` (retorno validado) |
| `LeerCantidadNoches` | **UI / Entrada** | Captura y asegura que las noches sean > 0. | `int` (retorno validado) |
| `MostrarResumen` | **UI / Salida** | Imprime la factura final formateada. | Múltiples datos de reserva |

---

##  3. Casos de Prueba (Validación Logica)
Se han definido los siguientes escenarios para garantizar la precisión de los cálculos:

**Escenario A: Reserva Corta (Sin Descuento)**
* **Entrada:** Habitación Sencilla ($80.000), 2 Noches.
* **Proceso:** Subtotal $160.000 -> Descuento $0 -> Impuesto $16.000.
* **Resultado Esperado:** Total $176.000.

**Escenario B: Reserva Larga (Con Descuento 15%)**
* **Entrada:** Habitación Doble ($150.000), 10 Noches.
* **Proceso:** Subtotal $1.500.000 -> Descuento $225.000 -> Impuesto $127.500.
* **Resultado Esperado:** Total $1.402.500.

---

##  4. Instrucciones de Ejecución
1.  **Requisitos:** Tener instalado el SDK de .NET.
2.  **Clonación:** `git clone https://github.com/brayanperez831-ctrl/SistemaReserbasHotel.git`
3.  **Ejecución:**
    ```bash
    dotnet run
    ```

---

##  5. Justificación de la Refactorización
* **Encapsulamiento:** Las funciones de cálculo son "puras"; no leen de consola ni imprimen, cumpliendo con las buenas prácticas de desarrollo.
* **Robustez:** Se implementó `int.TryParse` para evitar cierres inesperados (excepciones) ante entradas de texto no numéricas.
* **Documentación:** El 100% de las funciones cuentan con encabezados XML para facilitar el mantenimiento.

---
<div align="center">
Desarrollado para la asignatura de Programación - Unidad 3
</div>
