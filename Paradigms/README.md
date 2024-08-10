# Principles of Various Programming Paradigms

Though Alan Kay, the Computer Scientist who coined the term Object-Oriented Programming (OOP), lamented not making clear that the defining characteristic of an object-driven system was the concept of message passing, the paradigm still came to be well known for having an unrelated set of four pillars guiding its solutions. Functional programming also has a core set of principles guiding its solutions, but they typically aren't covered as thoroughly. Any paradigms beyond these two have sets of principles that are even more obscure, but it can be said that there are a few generally agreed upon by the industry.

## Object-Oriented Programming (OOP)
1. Encapsulation: Bundling of data and methods that operate on that data within a single unit or object.
2. Inheritance: Mechanism that allows a new class to be based on an existing class, inheriting its properties and methods.
3. Polymorphism: Ability of different classes to be treated as instances of the same class through a shared interface.
4. Abstraction: Hiding complex implementation details and showing only the necessary features of an object.

## Functional Programming (FP)
1. Immutability: Once created, data cannot be changed, promoting predictability and easier reasoning about code.
2. Pure Functions: Functions that always produce the same output for the same input and have no side effects.
3. First-Class and Higher-Order Functions: Functions can be assigned to variables, passed as arguments, and returned from other functions.
4. Recursion: A technique where a function calls itself to solve a problem by breaking it down into smaller instances.
5. Referential Transparency: An expression can be replaced with its value without changing the program's behavior.

## Logic Programming
1. Facts and Rules: Programs consist of a set of facts and rules that describe relationships and logic.
2. Unification: Process of making two different logical expressions identical by finding appropriate substitutions.
3. Backtracking: Algorithmic technique that abandons a solution as soon as it determines that it can't be completed.
4. Non-determinism: Ability to have multiple possible outcomes or solutions for a given input.
5. Declarative Problem Solving: Describing what needs to be solved rather than how to solve it.

## Concurrent Programming
1. Parallelism: Executing multiple computations simultaneously.
2. Synchronization: Coordinating the execution and data access of concurrent processes or threads.
3. Communication: Mechanisms for concurrent processes to exchange information.
4. Non-determinism: The order of execution in concurrent systems may vary between runs.
5. Scalability: Ability to handle growing amounts of work by adding resources to the system.

## Metaprogramming
1. Code Generation: Creating code at compile time or runtime.
2. Reflection: Ability of a program to examine, introspect, and modify its own structure and behavior.
3. Macros: Rules or patterns that specify how input text should be mapped to replacement output text.
4. Domain-Specific Languages (DSLs): Specialized languages tailored for specific problem domains.
5. Introspection: Ability of a program to examine its own properties at runtime.

## Reactive Programming
1. Data Streams: Modeling data and events as observable streams.
2. Propagation of Change: Changes in one data stream automatically flow through to related streams.
3. Declarative: Focusing on what to do rather than how to do it.
4. Asynchronous: Non-blocking execution model that doesn't halt program execution to wait for results.
5. Event-Driven: Programming paradigm in which the flow of the program is determined by events.

## Data-Oriented Design (DOD)
1. Data-Centric Approach: Organizing code and systems around the data being processed.
2. Cache Coherency: Optimizing data layout and access patterns for efficient use of CPU caches.
3. Contiguous Memory: Storing related data in contiguous memory locations for faster access.
4. Minimizing State: Reducing the amount of mutable state to simplify reasoning about the program.
5. Batch Processing: Processing data in large chunks to maximize throughput and efficiency.

## Array Programming
1. Vectorization: Applying operations to entire arrays or vectors at once.
2. Implicit Looping: Performing operations on arrays without explicit loop constructs.
3. Rank Polymorphism: Writing functions that can operate on arrays of any dimension.
4. Broadcasting: Automatically extending arrays of different shapes to compatible shapes for operations.
5. Reduction Operations: Collapsing arrays along one or more dimensions using operations like sum or product.

---

# Principios de Varios Paradigmas de Programación

Aunque Alan Kay, el científico informático que acuñó el término Programación Orientada a Objetos (POO), lamentó no haber dejado claro que la característica definitoria de un sistema basado en objetos era el concepto de paso de mensajes, el paradigma llegó a ser bien conocido por tener un conjunto no relacionado de cuatro pilares que guían sus soluciones. La programación funcional también tiene un conjunto central de principios que guían sus soluciones, pero típicamente no se cubren tan a fondo. Cualquier paradigma más allá de estos dos tiene conjuntos de principios que son aún más oscuros, pero se puede decir que hay algunos generalmente aceptados por la industria.

## Programación Orientada a Objetos (POO)
1. Encapsulación: Agrupación de datos y métodos que operan sobre esos datos dentro de una única unidad u objeto.
2. Herencia: Mecanismo que permite que una nueva clase se base en una clase existente, heredando sus propiedades y métodos.
3. Polimorfismo: Capacidad de diferentes clases de ser tratadas como instancias de la misma clase a través de una interfaz compartida.
4. Abstracción: Ocultar detalles de implementación complejos y mostrar solo las características necesarias de un objeto.

## Programación Funcional (PF)
1. Inmutabilidad: Una vez creados, los datos no pueden cambiarse, promoviendo la previsibilidad y facilitando el razonamiento sobre el código.
2. Funciones Puras: Funciones que siempre producen la misma salida para la misma entrada y no tienen efectos secundarios.
3. Funciones de Primera Clase y de Orden Superior: Las funciones pueden asignarse a variables, pasarse como argumentos y devolverse desde otras funciones.
4. Recursión: Técnica donde una función se llama a sí misma para resolver un problema dividiéndolo en instancias más pequeñas.
5. Transparencia Referencial: Una expresión puede ser reemplazada por su valor sin cambiar el comportamiento del programa.

## Programación Lógica
1. Hechos y Reglas: Los programas consisten en un conjunto de hechos y reglas que describen relaciones y lógica.
2. Unificación: Proceso de hacer idénticas dos expresiones lógicas diferentes encontrando sustituciones apropiadas.
3. Retroceso: Técnica algorítmica que abandona una solución tan pronto como determina que no puede completarse.
4. No Determinismo: Capacidad de tener múltiples resultados o soluciones posibles para una entrada dada.
5. Resolución de Problemas Declarativa: Describir qué necesita resolverse en lugar de cómo resolverlo.

## Programación Concurrente
1. Paralelismo: Ejecutar múltiples cálculos simultáneamente.
2. Sincronización: Coordinar la ejecución y el acceso a datos de procesos o hilos concurrentes.
3. Comunicación: Mecanismos para que los procesos concurrentes intercambien información.
4. No Determinismo: El orden de ejecución en sistemas concurrentes puede variar entre ejecuciones.
5. Escalabilidad: Capacidad de manejar cantidades crecientes de trabajo añadiendo recursos al sistema.

## Metaprogramación
1. Generación de Código: Crear código en tiempo de compilación o ejecución.
2. Reflexión: Capacidad de un programa para examinar, introspeccionar y modificar su propia estructura y comportamiento.
3. Macros: Reglas o patrones que especifican cómo el texto de entrada debe ser mapeado a texto de salida de reemplazo.
4. Lenguajes de Dominio Específico (DSLs): Lenguajes especializados adaptados para dominios de problemas específicos.
5. Introspección: Capacidad de un programa para examinar sus propias propiedades en tiempo de ejecución.

## Programación Reactiva
1. Flujos de Datos: Modelar datos y eventos como flujos observables.
2. Propagación de Cambios: Los cambios en un flujo de datos fluyen automáticamente a través de flujos relacionados.
3. Declarativa: Enfocarse en qué hacer en lugar de cómo hacerlo.
4. Asíncrona: Modelo de ejecución no bloqueante que no detiene la ejecución del programa para esperar resultados.
5. Basada en Eventos: Paradigma de programación en el que el flujo del programa está determinado por eventos.

## Diseño Orientado a Datos (DOD)
1. Enfoque Centrado en Datos: Organizar el código y los sistemas alrededor de los datos que se están procesando.
2. Coherencia de Caché: Optimizar el diseño y los patrones de acceso a datos para un uso eficiente de las cachés de CPU.
3. Memoria Contigua: Almacenar datos relacionados en ubicaciones de memoria contiguas para un acceso más rápido.
4. Minimización del Estado: Reducir la cantidad de estado mutable para simplificar el razonamiento sobre el programa.
5. Procesamiento por Lotes: Procesar datos en grandes bloques para maximizar el rendimiento y la eficiencia.

## Programación de Arrays
1. Vectorización: Aplicar operaciones a arrays o vectores enteros a la vez.
2. Bucles Implícitos: Realizar operaciones en arrays sin construcciones de bucle explícitas.
3. Polimorfismo de Rango: Escribir funciones que puedan operar en arrays de cualquier dimensión.
4. Difusión (Broadcasting): Extender automáticamente arrays de diferentes formas a formas compatibles para operaciones.
5. Operaciones de Reducción: Colapsar arrays a lo largo de una o más dimensiones usando operaciones como suma o producto.