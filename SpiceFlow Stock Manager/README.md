# SpiceFlow

Two users. One login form. Completely different worlds.

SpiceFlow is a full-stack inventory and order management 
platform where authentication isn't just about access —
it determines your entire experience. A customer and a 
manager share the same entry point but never see the 
same thing twice.

Built with C# and ASP.NET Core MVC from the ground up.
No shortcuts. No templates. Every layer designed and 
implemented from scratch.

## What happens when you log in

**As a Customer:**
You land on a live spice catalogue with real-time stock 
indicators. Add to cart, checkout, track your full order 
history, update your account details. Clean, fast, and 
exactly what a customer needs.

**As a Manager:**
Completely different dashboard. Full inventory control —
create new products, edit existing ones, delete old stock.
Monitor every order placed by every customer across the 
entire platform. Nothing crosses over. Nothing leaks.

The role-based routing that makes this seamless was the 
most architecturally satisfying problem in the entire build.

## Under the hood

- C# / ASP.NET Core MVC
- Entity Framework Core
- SQLite with full database migrations
- Repository pattern with clean service interfaces
- Role-based authentication with dynamic routing
- Razor Views with completely isolated layouts per role
- CSS and JavaScript

## Project structure
Controllers/ — Account, Client, Manager, Home
Entities/ — Order, Spice, User models
Services/ — Repository pattern and DB context
Views/ — Fully isolated views per user role
Migrations/ — Entity Framework database migrations
wwwroot/ — CSS and JavaScript assets


## How to run it

1. Clone the repo
2. Open `SpiceFlow Stock Manager.sln` in Visual Studio
3. Hit Run — database comes pre-seeded and ready to go
   No setup needed. It just works.

## What building this taught me

Role-based architecture forces you to think beyond 
just features. When two completely different users 
share one codebase without ever crossing paths, every 
single decision — controllers, views, authentication 
flow, data access patterns — has to be deliberate and 
clean. You can't hide lazy thinking behind a feature 
list when the architecture itself has to hold two 
separate realities together.

That's the kind of thinking SpiceFlow built in me.
