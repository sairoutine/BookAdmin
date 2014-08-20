create table BOOK_MASTER(
 BOOK_ISBN	 varchar(13),
 BOOK_NAME   text,
 BOOK_AUTHOR text,
 BOOK_ONSALE varchar(10),
 BOOK_PUBLISHER text,
 BOOK_URL varchar(255),
 BOOK_TAG text,
 BOOK_BORROWER varchar(4),
 BOOK_RETURNDATE varchar(10),
 primary key(BOOK_ISBN)
)