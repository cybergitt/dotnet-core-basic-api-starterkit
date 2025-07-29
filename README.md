# Basic API Starterkit

This project is an experiment trying to create an API solution starterkit that uses a Clean and Vertical Slice Architecture style.

## Architecture Overview

The way we build software keeps evolving. While **Clean Architecture** has been a favorite for .NET developers, **Vertical Slice Architecture** is gaining attention with its feature-focused approach.

### Vertical Slice Architecture

Vertical Slice Architecture introduces by [Jimmy Bogard](https://www.jimmybogard.com/vertical-slice-architecture/) and it offers this architecture against to traditional layered/onion/clean architecture approaches. Vertical Slice architecture aims to organize code around specific features or use cases, rather than technical concerns. In a Vertical Slice architecture, a feature is implemented across all layers of the software, from the user interface to the database.
Vertical Slice Architecture shines in scenarios where rapid development and delivery of independent features are critical. It’s well-suited for agile teams working on complex applications with numerous features that may change or evolve independently.

### Clean Architecture
On the other hand, Clean (also known as Hexagonal, Ports and Adapters, Onion) Architecture focuses on separation of concerns and dependency rules. It organizes code into layers, with the most stable and business-agnostic layers at the center (Entities, Use Cases) and external concerns like UI and Data Access on the outer layers.
Clean Architecture advocates for a more structured approach, ensuring that business logic is decoupled from external concerns. This approach is beneficial for long-term maintainability and scalability.