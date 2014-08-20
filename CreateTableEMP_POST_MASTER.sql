create table EMP_POST_MASTER(
 EMP_POST_ID	 int,
 EMP_POST_NAME	 varchar(255),
 primary key(EMP_POST_ID)
)

insert into EMP_POST_MASTER(
 EMP_POST_ID,
 EMP_POST_NAME
)
VALUES (1, '総務')

insert into EMP_POST_MASTER(
 EMP_POST_ID,
 EMP_POST_NAME
)
VALUES (2, '営業')

insert into EMP_POST_MASTER(
 EMP_POST_ID,
 EMP_POST_NAME
)
VALUES (3, '開発')