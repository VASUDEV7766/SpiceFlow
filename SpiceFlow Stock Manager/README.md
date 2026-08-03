# Spice Flow Manager App
An app to manage orders and spices inventory.

## Project Plan

### Presentation Layer (Views)
"5-7 views that are significant from the point of view of interactivity with the user"
- [ ] Home Dashboard
	- Shouldn't need a navigation bar, just a simple welcome screen with a button to sign in
	- [ ] Home View
		- [ ] Welcome message
		- [ ] Overview of the website
		- [ ] 'Sign In' button redirecting to Sign In view
	- [ ] Sign In View
		- [ ] User authentication (email, password)
		- [ ] 'Create an account' option & view
		- [ ] 'Forgot password' option & view
		- [ ] Sign-In form submit button
		- [ ] If Sign-In successful, redirect to client dashboard (Available Spices View)
		- [ ] but if `User.IsManager`, redirect to manager dashboard
	- [ ] Create Account View
		- [ ] Input fields for User model
		- [ ] Validate input fields
		- [ ] 'Sign Up' form button
		- [ ] Error if an input is invalid
		- [ ] Redirect to Sign In view if successful
	- [ ] Forgot Password View
		- [ ] Input field for email
		- [ ] Input field for new password
		- [ ] Input field for confirming new password
		- [ ] 'Update Password' button
		- [ ] Error if email not found in database or if passwords do not match
		- [ ] Redirect to Sign In view if successful
- [ ] Client Dashboard (navigation bar with links to Client views)
	- [ ] Available Spices View
		- [ ] Display all spices in Spices table
		- [ ] Stock indicator showing quantity available
		- [ ] 'Out of Stock' indicator if stock is 0
		- [ ] Feature an image of the spice maybe?
		- [ ] Add to Cart button
	- [ ] Cart View
		- [ ] View spices in cart
		- [ ] Remove from cart
		- [ ] Checkout Cart
	- [ ] Order History View
		- [ ] Display all orders placed by logged-in user
		- [ ] Cancel orders if not yet shipped
	- [ ] Account Settings View
		- [ ] View and update User details
	- [ ] Sign Out button in navigation bar
- [ ] Manager Dashboard (navigation bar with links to Manager views)
	- [ ] View for each table operations (Orders, Spices, Users)
		- [ ] Display all
		- [ ] Display details of one
		- [ ] Create
		- [ ] Update
		- [ ] Delete
	- [ ] Statistics view (e.g., total sales, most popular spices) 
		- Optional? Might be hard
- [ ] Website logo
- [ ] Separate navigation bars for Home, Client, and Manager

***

### Business Logic Layer (Services, Controllers)
"A business logic layer consisting of at least 3-4 significant business use-cases implemented by 4-7 business logic classes"
- [ ] Implement required View operations
	- [ ] HomeController
	- [ ] ClientController
	- [ ] ManagerController
- [ ] Table operations for Orders, Spices, Users
	- [ ] View all
	- [ ] View details of one
	- [ ] Create
	- [ ] Update
	- [ ] Delete
- [ ] Reset Password functionality would need a FindUserByEmail() method

***

### Models
- [ ] Implement validations for each model
	- [ ] Order model
	- [ ] Spice model
	- [ ] User model
- [ ] Create a User model
	- [ ] User fields: 
		- [ ] `int UserId`
		- [ ] `string Name`
		- [ ] `string Email`
		- [ ] `string Password`
		- [ ] `string Address`
		- [ ] `string PhoneNumber`
		- [ ] `boolean IsManager`
		- [ ] `string Cart` (for holding spices before checkout)
			- SQLite doesn't support lists, so we can store spices in a comma-separated string (ex: "`spiceId,spiceId,spiceId,...`")
	- [ ] Key relations with `Order`, Order should hold foreign key `UserId`
- [ ] Update Order model to include foreign key `UserId`
- [ ] Update Order model to use `string Spices` (see above) instead of only holding one `SpiceId`/`Spice` reference

***

### Data Layer
- [ ] Update OrderDbContext for User model creation and Order model changes
	- [ ] '`Users`' DbSet table
	- [ ] Update the seeding
	- [ ] Delete the old migration, make a new migration and update the database
	