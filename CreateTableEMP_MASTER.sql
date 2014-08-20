create table EMP_MASTER(
 EMP_CODE	 varchar(4),
 EMP_NAME	 varchar(255),
 EMP_NAME_K varchar(255),
 EMP_MAIL    varchar(255),
 EMP_POST    int,
 primary key(EMP_CODE),
 FOREIGN KEY (EMP_POST) REFERENCES EMP_POST_MASTER(EMP_POST_ID)
)