# PLANAZO - Sistema de gestión de eventos

## 1. Descripción de la aplicación

PLANAZO es una aplicación de consola desarrollada en C# y .NET que permite administrar eventos de entretenimiento, como películas, conciertos y talleres.

El sistema permite consultar eventos, realizar reservas, controlar los cupos disponibles, cancelar reservas y consultar el resumen de las entradas reservadas.

El proyecto fue desarrollado aplicando los conceptos de Programación Orientada a Objetos estudiados durante el curso.

## 2. Funcionalidades implementadas

- Consultar los eventos disponibles.
- Consultar la información de un evento por su identificador.
- Registrar reservas de entradas.
- Validar la cantidad de entradas.
- Controlar los cupos disponibles.
- Cancelar reservas.
- Evitar cancelar una reserva más de una vez.
- Consultar las reservas realizadas.
- Consultar las reservas asociadas a un usuario.
- Mostrar el resumen de reservas activas.
- Calcular el precio final según el tipo de evento.

## 3. Tecnologías utilizadas

- C#
- .NET
- Visual Studio Code
- Git
- GitHub

## 4. Instrucciones para ejecutar el proyecto

1. Descargar o clonar el repositorio.
2. Abrir la carpeta del proyecto en Visual Studio Code.
3. Abrir la terminal.
4. Ejecutar el siguiente comando:

```bash
dotnet run
```

5. Utilizar el menú para consultar eventos, realizar reservas y cancelar entradas.

## 5. Organización de las clases

### Evento

Es la clase abstracta que contiene los datos comunes de los eventos, como identificador, nombre, fecha, precio base, capacidad máxima y cupos disponibles.

También contiene los métodos para reservar cupos, devolver cupos y mostrar información.

### Cine

Hereda de Evento y conserva el precio base.

### Concierto

Hereda de Evento y aumenta el precio base un 15 %.

### Taller

Hereda de Evento y aplica un descuento del 10 %.

### Evento Deportivo

Es una clase adicional que hereda de Evento y aumenta el precio base un 20 %.

### Usuario

Representa a la persona que realiza las reservas.

### Reserva

Relaciona al usuario con un evento y guarda la cantidad de entradas, el valor total y el estado de la reserva.

### Gestor de Reservas

Administra los eventos y las reservas. También permite consultar eventos, crear reservas, cancelar reservas y mostrar el resumen.

### Program

Contiene el menú principal y permite al usuario interactuar con el sistema.

## 6. Aplicación de los conceptos de POO

### Encapsulamiento

Se utilizaron propiedades con `private set` para proteger los datos de los eventos y las reservas.

Por ejemplo, los cupos disponibles no se modifican directamente desde el menú. Se utilizan los métodos `ReservarCupos()` y `DevolverCupos()` para controlar sus modificaciones.

### Abstracción

Se creó la clase abstracta `Evento`, que representa las características comunes de los eventos.

No se crean eventos directamente desde esta clase, sino desde sus clases derivadas.

### Herencia

Las clases `Cine`, `Concierto`, `Taller` y `EventoDeportivo` heredan de `Evento`.

De esta manera, reutilizan sus propiedades y métodos.

### Polimorfismo

Cada tipo de evento implementa el método `CalcularPrecioFinal()` de manera diferente.

El cine conserva el precio base, el concierto aumenta el precio un 15 %, el taller aplica un descuento del 10 % y el evento deportivo aumenta el precio un 20 %.

### Composición y asociaciones

La clase `Reserva` contiene una referencia a un `Usuario` y a un `Evento`.

El `GestorReservas` administra las listas de eventos y reservas.

Estas relaciones permiten organizar la información y mantener separadas las responsabilidades.

### Colecciones

Se utilizaron `List<Evento>` y `List<Reserva>` para almacenar los eventos y las reservas.

Esto permite registrar varios elementos y recorrerlos mediante ciclos.

### Excepciones

Se utilizaron excepciones para controlar errores como cantidades negativas, eventos inexistentes, cupos insuficientes y cancelaciones repetidas.

El menú utiliza `try/catch` para mostrar los errores sin cerrar inesperadamente el programa.

## 7. Casos de prueba

Se realizaron pruebas para verificar:

1. Registrar una reserva válida.
2. Intentar reservar más entradas que los cupos disponibles.
3. Intentar realizar una reserva con una cantidad negativa.
4. Cancelar una reserva y comprobar la devolución de cupos.
5. Intentar cancelar dos veces la misma reserva.
6. Consultar un evento inexistente.
7. Comprobar el cálculo de precios de cada tipo de evento.

Las capturas de pantalla de las pruebas se encuentran en la carpeta `Capturas`.

## 8. Pregunta de sustentación

### ¿Por qué utilizaste una clase abstracta Evento en lugar de crear clases completamente independientes para Cine, Concierto y Taller? ¿Qué ventajas tiene esta decisión cuando necesitamos agregar un nuevo tipo de evento?

Utilicé una clase abstracta llamada `Evento` porque los eventos tienen características en común, como el identificador, el nombre, la fecha, el precio base, la capacidad máxima y los cupos disponibles.

En lugar de repetir estas propiedades y métodos en las clases Cine, Concierto y Taller, los coloqué en una clase principal para que las demás clases pudieran heredarlos.

También utilicé el método `CalcularPrecioFinal()` de forma abstracta, porque cada evento tiene una manera diferente de calcular su precio.

Por ejemplo, el cine conserva el precio base, el concierto aumenta el precio un 15 % y el taller aplica un descuento del 10 %.

Esta decisión permite reutilizar código, mantener el programa organizado y evitar repetir la misma lógica.

Si necesitamos agregar un nuevo tipo de evento, podemos crear una clase que herede de `Evento` y definir su propio cálculo de precio, sin modificar las clases que ya existen.

Por ejemplo, en el proyecto se agregó `EventoDeportivo`, que aumenta el precio base un 20 %.

De esta manera, el sistema puede incorporar nuevos eventos de forma más sencilla y mantener una estructura organizada.

## 9. Capturas de pantalla

En esta sección se adjuntan las capturas de pantalla de las pruebas realizadas:

- Consulta de eventos.
  <img width="274" height="521" alt="image" src="https://github.com/user-attachments/assets/fa20f092-01f1-46be-8f3c-f9046fe0071c" />

- Reserva válida.
  <img width="261" height="433" alt="image" src="https://github.com/user-attachments/assets/9da46640-80ed-40e2-80f8-1419e07ec669" />

- Validación de cupos.
  <img width="246" height="503" alt="image" src="https://github.com/user-attachments/assets/1ed682ac-7558-4af3-b715-7dccbf9cace3" />
  
- Validación de cantidad negativa.
  <img width="327" height="320" alt="image" src="https://github.com/user-attachments/assets/0d819d90-f5a6-4dca-946e-95d268682c21" />

- Cancelación de reserva.
  <img width="267" height="298" alt="image" src="https://github.com/user-attachments/assets/8e86e065-733f-44fb-86fd-1923fb9946e8" />

- Cancelación repetida.
  <img width="275" height="301" alt="image" src="https://github.com/user-attachments/assets/6a79f6e6-3cd2-4d88-93e0-cdf6a9749367" />

- Consulta de evento inexistente.
  <img width="260" height="262" alt="image" src="https://github.com/user-attachments/assets/61a4cd7c-9926-400d-931d-1006e54db971" />

- Resumen de reservas.
  <img width="254" height="307" alt="image" src="https://github.com/user-attachments/assets/e737b06c-a7ca-42c5-8395-5441aae13b9e" />


## 10. Autor

Proyecto desarrollado como parte del parcial de Programación Orientada a Objetos con C# y .NET.
