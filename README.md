# OnionArchCqrs-ECommerce

## Project Description

**OnionArchCqrs-ECommerce** is an **e-commerce application** built using **CQRS (Command Query Responsibility Segregation)** and **Mediatr** patterns. It is structured based on **Onion Architecture**, and integrates **ElasticSearch** for fast search and **Redis** for caching. This project also utilizes **Cloud** technologies to enhance scalability and performance. The goal of the project is to demonstrate clean and maintainable software architecture.

---

## Technologies Used

This project utilizes the following technologies:

- **CQRS (Command Query Responsibility Segregation)**: Separates read and write operations to enhance scalability and maintainability.
- **Mediatr**: Simplifies communication within the application by managing commands and queries through handlers.
- **ElasticSearch**: Allows fast searching and querying over large data sets.
- **Redis**: Provides caching and fast data retrieval to improve application performance.
- **Onion Architecture**: Follows a layered architecture to minimize dependencies, offering flexibility and testability.
- **Cloud**: Utilizes cloud services for enhanced scalability, flexibility, and performance optimization.

---

## Project Structure

The project follows **Onion Architecture** principles and is divided into the following layers:

1. **Core**: Contains the business logic and domain models of the application.
2. **Application**: Handles application services and operations, implementing CQRS and Mediatr patterns.
3. **Infrastructure**: Manages data access, external service integrations, and infrastructure dependencies (ElasticSearch, Redis, etc.).
4. **API**: Exposes HTTP APIs for users to interact with the application.

---

## Features

- **Fast Search**: ElasticSearch is used to enable fast searching of products.
- **Caching**: Redis is used to cache frequently accessed data to enhance performance.
- **CQRS & Mediatr**: Command and query operations are clearly separated, and each operation is managed by a handler, leading to cleaner and more maintainable code.
- **Onion Architecture**: The architecture minimizes dependencies and improves testability.
- **Cloud Integration**: The project leverages cloud technologies for improved scalability and performance, ensuring high availability and reliability.
