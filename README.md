# SpiceFlow

Most inventory apps are built for one type of user.
SpiceFlow is built for two — and they never see the 
same thing twice.

A customer and a manager both log in through the same 
form. But the moment they're in, their worlds split 
completely. Different dashboards, different capabilities, 
different everything. Same codebase holding it all together.

## What each user gets

**Customer side:**
A clean spice catalogue with live stock indicators. 
Add things to your cart, check out, track your orders, 
update your account. Simple and fast.

**Manager side:**
Full control. Add new products, edit existing ones, 
remove old stock. See every order placed by every 
customer across the entire platform. Nothing a customer 
sees, you see differently.

Getting the routing logic to work cleanly between the 
two was honestly the most satisfying part of building this.

## Tech stack

- C# / ASP.NET Core MVC
- Entity Framework Core with SQLite
- Role-based authentication with dynamic routing
- Repository pattern with clean service interfaces
- Razor Views — completely isolated per user role

## How to run it

1. Clone the repo
2. Open `SpiceFlow Stock Manager.sln` in Visual Studio
3. Hit Run — database is pre-seeded, no setup needed

## What building this taught me

When two completely different users share one codebase 
without ever crossing paths, you can't hide lazy thinking 
behind a feature list. Every layer has to be intentional.
That's the kind of thinking this project built in me.
