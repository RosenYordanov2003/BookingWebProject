# Booking Web Project

## About
This is educational web project for Asp.Net Advanced course in SoftUni.

The application represents booking system where the users can book rooms in hotels or rent a car.
Every hotel has hotel benefits for example: spa, room service, allow pets and etc. Hotels also have list of room types. Every room type has diiferent capacity and different price, depends on the room type.
Every room type has different packages for example: bed and breakfast, bed, breakfast and dinner and all inclusive package. Every room package has a different price depends on the package.
Only unique room types have been showed when user looks hotel rooms for example: therre is 4 rooms from Single bed room type and only 1 is visualized, every room from the same type have same things.
Every room has room basis for example: tv, shower, vault, air conditional and etc.
## The application has 3 roles:
### User Role
User can filter and sort their hotels and cars to rent by given criteria, can add hotels to their list from favorite hotels. 
User also can post comments on hotels. The comments which belong on the user can be edited or deleted only by their author.
Every user has a reservation history where are all user reservations and every reservation can be viewed in details by the user who has made it.
## Admin Role
Admin user can modify: hotels, room basis, rooms, hotel benefits, room packages and cars.
Admin user can see all statistics about the app for example total reservations made in the application and can see total hotel reservations count and total reservations made cars.
Only the admin user can change the roles of other users.
## Modeator
Moderator user can modify: hotels, room basis, rooms, hotel benefits, room packages and cars.
Moderator user can see all statistics about the app for example total reservations made in the application and can see total hotel reservations count and total reservations made cars.

## Functuonality
Authenticated users can see: hoome page, all hotle pages, all room pages, personalization page, user favorite hotels page, user reservation pages, all reservation pages and all car pages.
The anonymous ones ca see: home page, car pages and register, login pages.
These are the registration and login pages

![image](https://github.com/RosenYordanov2003/BookingWebProject/assets/107473016/65ed8384-b8db-459b-911a-02b605290e8b)

![image](https://github.com/RosenYordanov2003/BookingWebProject/assets/107473016/66c59eb0-3f4d-40e5-8595-ef352d9ae3e2)

This is the Home Page: 

![image](https://github.com/RosenYordanov2003/BookingWebProject/assets/107473016/ad9ae066-e4e2-4d9a-ad42-7284987804f1)

Hotels which are visualized are the hotels with the most reservations count.

![image](https://github.com/RosenYordanov2003/BookingWebProject/assets/107473016/3da7b00e-b44c-480c-95b5-c0d81f022d89)

Only not deleted hotels and cars are accessible for the user.
If user tries to reserve car or room from particular room type and car or room is already reserved warning message is visualized to the user with message: (Car or Room) is already reserved for this period.
For the room reservation all rooms by given type are checked for reservation that may cause а conflic with the dates which are given from the user.
Only not deleted room packages are available form the rooms and only not deleted room types are accessible for the users. If room type is deleted, all rooms by this type are automatically not available


