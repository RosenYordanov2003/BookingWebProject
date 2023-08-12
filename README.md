# Booking Web Project

## About
### The application design is custom created from me and is fully responsive for all devices. From 280px width to 1920px width.
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

## Database diagram

![image](https://github.com/RosenYordanov2003/BookingWebProject/assets/107473016/5e70031f-7b89-4e36-8f06-6836964ee16d)

![image](https://github.com/RosenYordanov2003/BookingWebProject/assets/107473016/a8b09727-17be-4c87-8c77-73dd76b6a731)

![image](https://github.com/RosenYordanov2003/BookingWebProject/assets/107473016/ea8725d9-e359-4a75-9d70-72ec57eabf81)




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

- Only not deleted hotels and cars are accessible for the user.
If user tries to reserve car or room from particular room type and car or room is already reserved warning message is visualized to the user with message: (Car or Room) is already reserved for this period.
- For the room reservation all rooms by given type are checked for reservation that may cause а conflic with the dates which are given from the user.
- Only not deleted room packages are available form the rooms and only not deleted room types are accessible for the users. If room type is deleted, all rooms by this type are automatically not available
- If user search for not existing rent car, hotel or room type, NotFound response is returned with custom excpetion page for 404. (Chane environment if you want to see custom error  pages)
- Hotel All, RentCar All, Hotel Details and some admin pages have pagination.
RentCar All page

![image](https://github.com/RosenYordanov2003/BookingWebProject/assets/107473016/d5a45338-9eea-44b6-aa46-756aba01e770)

![image](https://github.com/RosenYordanov2003/BookingWebProject/assets/107473016/23d6040f-5628-4fcb-81bb-01cc487df5a9)


![image](https://github.com/RosenYordanov2003/BookingWebProject/assets/107473016/67e2d580-9d9b-4de5-b44d-4f11b70c9d0a)

Hotel All page

![image](https://github.com/RosenYordanov2003/BookingWebProject/assets/107473016/7a06c723-cc42-4684-a0ae-6a5f3a05f02c)

![image](https://github.com/RosenYordanov2003/BookingWebProject/assets/107473016/58cc07c7-0cad-4291-83e1-69bb0d0b18b9)

![image](https://github.com/RosenYordanov2003/BookingWebProject/assets/107473016/a28e918d-b40d-43b2-a96e-b7de9f27ad99)

I have used Leaflet appi for visualizing hotel location, also for car location where car have to be picked up.

![image](https://github.com/RosenYordanov2003/BookingWebProject/assets/107473016/7d055f37-1a19-4ddd-a5c4-93013dfb69b1)

I have used geolocation if user allows to get his location, for calculating the distance between (hotel, car) location adn user current location

![image](https://github.com/RosenYordanov2003/BookingWebProject/assets/107473016/bffece16-a91e-4bf0-a54c-bf7c0ae3a7e0)

User personal info page
Set your path when you decide to delete your profile picture, becase can throw an exception

![image](https://github.com/RosenYordanov2003/BookingWebProject/assets/107473016/65a8783d-b7c1-4083-bd38-1b55f85ba735)

Room page by given hotel id

![image](https://github.com/RosenYordanov2003/BookingWebProject/assets/107473016/730098ad-8036-4e4e-a33f-d90914a2bd8d)

Admin page
![image](https://github.com/RosenYordanov2003/BookingWebProject/assets/107473016/3274e04f-58e5-4193-93bf-0f3a8d67b5e1)

I have used local storage to save the state of the color, when switching the light modes and for menu state.

![image](https://github.com/RosenYordanov2003/BookingWebProject/assets/107473016/b960d5bc-e04d-442e-a081-2c4fa4bf3a8f)

![image](https://github.com/RosenYordanov2003/BookingWebProject/assets/107473016/3fcfbc02-c678-4d88-9017-81edf8eb2aa3)

![image](https://github.com/RosenYordanov2003/BookingWebProject/assets/107473016/6acfef5f-da70-4e21-ad6c-f21d5b7b3316)

Too see more download the project and enjoy :)

## Тechnologies I have used
- C#
- ASP.NET with MVC pattern
- Entity Framework core
- Microsoft SQL Server
- JavaScript
- Html
- Css
- Ajax
- Git
  










