create table Teachers (TeacherId int primary key, TeacherName varchar(100) not null);

create table Students (StudentId int primary key, StudentName varchar(100) not null);

create table Courses (CourseId int primary key, CourseName varchar(100) not null unique, TeacherId int foreign key references Teachers(TeacherId));

create table Lessons (LessonId int primary key, LessonName varchar(100) not null, CourseId int foreign key references Courses(CourseId));

insert into Teachers values(1, 'Sally');
insert into Teachers values(2, 'Josh');
insert into Teachers values(3, 'John');

insert into Students values(1, 'Nick');
insert into Students values(2, 'Temirlan');
insert into Students values(3, 'Bolat');
insert into Students values(4, 'Aidana');
insert into Students values(5, 'Dana');

insert into Courses values(1, 'Biology', 1);
insert into Courses values(2, 'Chemistry', 3);
insert into Courses values(3, 'Maths', 2);

insert into Lessons values(1, 'Logarithms', 3);
insert into Lessons values(2, 'Moles', 2);
insert into Lessons values(3, 'Derivatives', 3);
insert into Lessons values(4, 'Cells', 1);

select * from Teachers;
select * from Students;
select * from Courses;
select * from Lessons;