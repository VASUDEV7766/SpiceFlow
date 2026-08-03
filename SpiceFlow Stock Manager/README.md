# SpiceFlow

Most web apps built by students are simple CRUD apps 
with one type of user. SpiceFlow is different.

It's a full-stack inventory and order management system 
where a customer and a manager log into the same app 
but land in completely different worlds. Same login form. 
Completely different experience depending on who you are.

## What happens when you log in

**As a Customer:**
You land on a spice browsing page with live stock 
indicators. Add things to your cart, check out, track 
your order history, update your account. Clean and simple.

**As a Manager:**
You get a completely separate dashboard. Full control 
over inventory — add new spices, edit details, delete 
stock. See every order placed by every customer. 
Manage it all from one place.

The routing logic that makes this work cleanly was 
honestly the most satisfying part to build.

## What's under the hood

- C# / ASP.NET Core MVC
- Entity Framework Core with SQLite
- Repository pattern with service interfaces
- Role-based authentication and routing
- Razor Views with separate layouts for customers 
  and managers
- CSS and JavaScript in wwwroot

## Project structure
