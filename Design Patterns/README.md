# Design Patterns Repository

Welcome to this comprehensive Design Patterns repository! This project aims to provide clear examples and explanations of various software design patterns across multiple programming languages.

## Table of Contents

1. [Creational Patterns](#creational-patterns)
2. [Structural Patterns](#structural-patterns)
3. [Behavioral Patterns](#behavioral-patterns)
4. [Concurrency Patterns](#concurrency-patterns)
5. [Architectural Patterns](#architectural-patterns)
6. [Miscellaneous Patterns](#miscellaneous-patterns)

## Creational Patterns

Creational patterns focus on object creation mechanisms, providing flexibility in what gets created, how it's created, and when.

### Singleton
Ensures a class has only one instance and provides a global point of access to it.

### Factory Method
Defines an interface for creating an object, but lets subclasses decide which class to instantiate.

### Abstract Factory
Provides an interface for creating families of related or dependent objects without specifying their concrete classes.

### Builder
Separates the construction of a complex object from its representation, allowing the same construction process to create various representations.

### Prototype
Specifies the kinds of objects to create using a prototypical instance, and creates new objects by copying this prototype.

## Structural Patterns

Structural patterns deal with object composition, creating relationships between objects to form larger structures.

### Adapter
Allows incompatible interfaces to work together by wrapping an object in an adapter to make it compatible with another class.

### Bridge
Separates an object's abstraction from its implementation, allowing them to vary independently.

### Composite
Composes objects into tree structures to represent part-whole hierarchies, letting clients treat individual objects and compositions uniformly.

### Decorator
Attaches additional responsibilities to an object dynamically, providing a flexible alternative to subclassing for extending functionality.

### Facade
Provides a unified interface to a set of interfaces in a subsystem, defining a higher-level interface that makes the subsystem easier to use.

### Flyweight
Uses sharing to support large numbers of fine-grained objects efficiently.

### Proxy
Provides a surrogate or placeholder for another object to control access to it.

## Behavioral Patterns

Behavioral patterns are concerned with algorithms and the assignment of responsibilities between objects.

### Chain of Responsibility
Passes a request along a chain of handlers, allowing each handler to decide either to process the request or to pass it to the next handler.

### Command
Encapsulates a request as an object, allowing you to parameterize clients with different requests, queue or log requests, and support undoable operations.

### Interpreter
Defines a representation for a language's grammar along with an interpreter that uses the representation to interpret sentences in the language.

### Iterator
Provides a way to access the elements of an aggregate object sequentially without exposing its underlying representation.

### Mediator
Defines an object that encapsulates how a set of objects interact, promoting loose coupling by keeping objects from referring to each other explicitly.

### Memento
Captures and externalizes an object's internal state so that the object can be restored to this state later.

### Observer
Defines a one-to-many dependency between objects so that when one object changes state, all its dependents are notified and updated automatically.

### State
Allows an object to alter its behavior when its internal state changes. The object will appear to change its class.

### Strategy
Defines a family of algorithms, encapsulates each one, and makes them interchangeable. Strategy lets the algorithm vary independently from clients that use it.

### Template Method
Defines the skeleton of an algorithm in an operation, deferring some steps to subclasses. Template Method lets subclasses redefine certain steps of an algorithm without changing the algorithm's structure.

### Visitor
Represents an operation to be performed on the elements of an object structure. Visitor lets you define a new operation without changing the classes of the elements on which it operates.

## Concurrency Patterns

Concurrency patterns are those that deal with the multi-threaded programming paradigm.

### Producer-Consumer
Separates the production and consumption of data, allowing these processes to operate asynchronously.

### Read-Write Lock
Allows concurrent read access to an object but requires exclusive access for write operations.

### Thread Pool
Manages a pool of worker threads to execute tasks, reducing the overhead of thread creation.

## Architectural Patterns

Architectural patterns address various parts of the software architecture.

### Model-View-Controller (MVC)
Separates an application into three interconnected components: the model (data), the view (user interface), and the controller (processes that handle input).

### Model-View-ViewModel (MVVM)
A variation of MVC pattern, tailored for modern UI development frameworks, especially in the context of data binding.

### Microservices
Structures an application as a collection of loosely coupled services, which implement business capabilities.

## Miscellaneous Patterns

These patterns don't fit neatly into the above categories but are widely used in software development.

### Dependency Injection
A technique whereby one object supplies the dependencies of another object.

### Lazy Loading
A design pattern that defers the initialization of an object until the point at which it is needed.

### Service Locator
Encapsulates the processes involved in obtaining a service with a strong abstraction layer.

## Contributing

Contributions to this repository are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.

# Repositorio de Patrones de Diseño

¡Bienvenido a este completo repositorio de Patrones de Diseño! Este proyecto tiene como objetivo proporcionar ejemplos claros y explicaciones de varios patrones de diseño de software en múltiples lenguajes de programación.

## Tabla de Contenidos

1. [Patrones Creacionales](#patrones-creacionales)
2. [Patrones Estructurales](#patrones-estructurales)
3. [Patrones de Comportamiento](#patrones-de-comportamiento)
4. [Patrones de Concurrencia](#patrones-de-concurrencia)
5. [Patrones Arquitectónicos](#patrones-arquitectónicos)
6. [Patrones Misceláneos](#patrones-misceláneos)

## Patrones Creacionales

Los patrones creacionales se enfocan en mecanismos de creación de objetos, proporcionando flexibilidad en lo que se crea, cómo se crea y cuándo.

### Singleton
Asegura que una clase tenga solo una instancia y proporciona un punto de acceso global a ella.

### Método Fábrica
Define una interfaz para crear un objeto, pero permite a las subclases decidir qué clase instanciar.

### Fábrica Abstracta
Proporciona una interfaz para crear familias de objetos relacionados o dependientes sin especificar sus clases concretas.

### Constructor
Separa la construcción de un objeto complejo de su representación, permitiendo que el mismo proceso de construcción cree varias representaciones.

### Prototipo
Especifica los tipos de objetos a crear utilizando una instancia prototípica y crea nuevos objetos copiando este prototipo.

## Patrones Estructurales

Los patrones estructurales tratan con la composición de objetos, creando relaciones entre objetos para formar estructuras más grandes.

### Adaptador
Permite que interfaces incompatibles trabajen juntas envolviendo un objeto en un adaptador para hacerlo compatible con otra clase.

### Puente
Separa la abstracción de un objeto de su implementación, permitiendo que varíen independientemente.

### Composite
Compone objetos en estructuras de árbol para representar jerarquías de parte-todo, permitiendo a los clientes tratar objetos individuales y composiciones de manera uniforme.

### Decorador
Adjunta responsabilidades adicionales a un objeto dinámicamente, proporcionando una alternativa flexible a la subclasificación para extender la funcionalidad.

### Fachada
Proporciona una interfaz unificada a un conjunto de interfaces en un subsistema, definiendo una interfaz de nivel superior que hace que el subsistema sea más fácil de usar.

### Peso Ligero
Utiliza el compartir para admitir grandes cantidades de objetos de grano fino de manera eficiente.

### Proxy
Proporciona un sustituto o marcador de posición para otro objeto para controlar el acceso a él.

## Patrones de Comportamiento

Los patrones de comportamiento se ocupan de los algoritmos y la asignación de responsabilidades entre objetos.

### Cadena de Responsabilidad
Pasa una solicitud a lo largo de una cadena de manejadores, permitiendo que cada manejador decida procesar la solicitud o pasarla al siguiente manejador.

### Comando
Encapsula una solicitud como un objeto, permitiéndote parametrizar clientes con diferentes solicitudes, encolar o registrar solicitudes, y soportar operaciones deshacer.

### Intérprete
Define una representación para la gramática de un lenguaje junto con un intérprete que usa la representación para interpretar oraciones en el lenguaje.

### Iterador
Proporciona una forma de acceder secuencialmente a los elementos de un objeto agregado sin exponer su representación subyacente.

### Mediador
Define un objeto que encapsula cómo un conjunto de objetos interactúa, promoviendo el acoplamiento débil al evitar que los objetos se refieran entre sí explícitamente.

### Memento
Captura y externaliza el estado interno de un objeto para que el objeto pueda ser restaurado a este estado más tarde.

### Observador
Define una dependencia de uno a muchos entre objetos para que cuando un objeto cambie de estado, todos sus dependientes sean notificados y actualizados automáticamente.

### Estado
Permite que un objeto altere su comportamiento cuando su estado interno cambia. El objeto parecerá cambiar su clase.

### Estrategia
Define una familia de algoritmos, encapsula cada uno y los hace intercambiables. La estrategia permite que el algoritmo varíe independientemente de los clientes que lo utilizan.

### Método Plantilla
Define el esqueleto de un algoritmo en una operación, difiriendo algunos pasos a las subclases. El Método Plantilla permite que las subclases redefinan ciertos pasos de un algoritmo sin cambiar la estructura del algoritmo.

### Visitante
Representa una operación a realizar en los elementos de una estructura de objetos. El Visitante te permite definir una nueva operación sin cambiar las clases de los elementos sobre los que opera.

## Patrones de Concurrencia

Los patrones de concurrencia son aquellos que tratan con el paradigma de programación multihilo.

### Productor-Consumidor
Separa la producción y el consumo de datos, permitiendo que estos procesos operen de forma asíncrona.

### Bloqueo de Lectura-Escritura
Permite el acceso de lectura concurrente a un objeto pero requiere acceso exclusivo para las operaciones de escritura.

### Pool de Hilos
Gestiona un conjunto de hilos de trabajo para ejecutar tareas, reduciendo la sobrecarga de la creación de hilos.

## Patrones Arquitectónicos

Los patrones arquitectónicos abordan varias partes de la arquitectura del software.

### Modelo-Vista-Controlador (MVC)
Separa una aplicación en tres componentes interconectados: el modelo (datos), la vista (interfaz de usuario) y el controlador (procesos que manejan la entrada).

### Modelo-Vista-VistaModelo (MVVM)
Una variación del patrón MVC, adaptada para marcos de desarrollo de UI modernos, especialmente en el contexto del enlace de datos.

### Microservicios
Estructura una aplicación como una colección de servicios débilmente acoplados que implementan capacidades de negocio.

## Patrones Misceláneos

Estos patrones no encajan neatamente en las categorías anteriores pero son ampliamente utilizados en el desarrollo de software.

### Inyección de Dependencias
Una técnica mediante la cual un objeto suministra las dependencias de otro objeto.

### Carga Perezosa
Un patrón de diseño que difiere la inicialización de un objeto hasta el punto en que se necesita.

### Localizador de Servicios
Encapsula los procesos involucrados en la obtención de un servicio con una fuerte capa de abstracción.

## Contribuir

¡Las contribuciones a este repositorio son bienvenidas! Por favor, siéntete libre de enviar una Solicitud de Extracción (Pull Request).

## Licencia

Este proyecto está licenciado bajo la Licencia MIT - consulta el archivo [LICENSE.md](LICENSE.md) para más detalles.