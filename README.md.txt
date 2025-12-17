# Task Management API

A simple **Task Management API** built with **.NET 8**, demonstrating **Clean Architecture**, **Dependency Injection**, **Background Services**, and **External API Integration**.

---

## Approach

This project is designed to **demonstrate key backend concepts** in a clean and structured way:

1. **Clean Architecture**:  
   - **API**:
   - **Services**:
   - **Repositories**: 

2. **Dependency Injection (DI) & Service Lifetimes**:  
   - `Scoped`: `TaskService`
   - `Singleton`: `ITimeProvider`
   - `Transient`: `IMessageServices 
   This demonstrates **interface-based design** and different DI lifetimes.  

3. **Background Service**:  
   - `TaskNotificationService` runs **every 30 seconds** and logs information.  
   - This simulates **recurring background jobs** in a backend application.  

4. **External HTTP Request**:  
   - `ExternalPostService` fetches posts from [JSONPlaceholder](https://jsonplaceholder.typicode.com/posts)  
   - Includes **error handling** and **logging**.  

5. **In-Memory Database**:  
   - The application uses a simple **in-memory list** to store tasks, keeping it lightweight and fully functional without setting up a real database.  

---

## Summary

- **Clean Architecture** with clear separation of concerns  
- **Repository pattern** with **interface-based design**  
- **Dependency Injection** showing different lifetimes  
- **Background service** that runs every 30 seconds simulating a job  
- **External API integration** with proper error handling  
- **In-memory database** to make the application fully functional  


