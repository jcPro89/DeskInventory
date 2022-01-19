# jcDeskInventory
CRUD application for keeping inventory control

1- ADD new product: user inputs product code, name and description
2- LIST all producs: user can navigate through all products in a grid view
3- UPDATE product info: user can search using product code, name or department, and then update product information
4- DELETE product: user can search using product code, name or department, and then update product information

*Others:*
Code for substracting last added product to inventory
Code for substracting a product: enter substract-code and then input product code for substracting it from inventory


Database

Categories: CategoryId, CategorgyName
Users: UserId, UserFullName, UserName, UserPassword
Events: EventId, UserId FK, EventType, EventDescription, EventDateTime
Products: ProductId PK, CategoryId FK, ProductCode, ProductName, ProductDescription, ProductCurrentQuantity

_Version history_

v0.1 - Add new product to database