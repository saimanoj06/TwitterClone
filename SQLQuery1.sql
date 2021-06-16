select * from Tweets

create Database TwitterDB

use TwitterDB

create Table Persons 
(
UserId varchar(25) Primary key,
Password varchar(50) not null, 
FullName varchar(30) not null,
Email varchar(50) not null,
JoinedDate Date not null,
Active bit not null
) 

create Table Tweets
( 
TweetId int Identity primary key ,
UserId varchar(25) FOREIGN KEY REFERENCES Persons(UserId),
Message varchar(150) not null,
CreatedDate date not null
)

alter Table Tweets alter column CreatedDate DateTime
create Table Followings 
(
Id int Primary Key,
UserId varchar(25) FOREIGN KEY REFERENCES Persons(UserId),
FollowingId varchar(25)  FOREIGN KEY REFERENCES Persons(UserId)
)

select * from Persons
select * from Followings
select * from Tweets

Delete from Persons