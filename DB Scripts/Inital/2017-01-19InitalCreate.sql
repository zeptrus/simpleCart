begin transaction

use SimpleCart;

create table [Order]
(
	Id [bigint] Primary Key,
	CustomerId [bigint] Not Null,
	TotalPaid [decimal] Not Null,
	DatePlaced [datetime] NOT NULL,
);

create table [Customer]
(
	Id [bigint] Primary Key,
	FirstName [nvarchar](100) Not Null,
	LastName [nvarchar](100) Not Null
);

GO

ALTER TABLE [Order]  WITH CHECK ADD  CONSTRAINT [FK_Customer] FOREIGN KEY([CustomerId])
REFERENCES [Customer] ([Id]);

GO

INSERT [Customer] ([Id], [FirstName], [LastName]) VALUES (1228, 'Cody', 'Smith');
INSERT [Customer] ([Id], [FirstName], [LastName]) VALUES (1876, 'Gavin', 'Bowers');
INSERT [Customer] ([Id], [FirstName], [LastName]) VALUES (2433, 'Ashley', 'Anderson');
INSERT [Customer] ([Id], [FirstName], [LastName]) VALUES (7765, 'Jen', 'Gunderson');
INSERT [Customer] ([Id], [FirstName], [LastName]) VALUES (7860, 'Alex', 'Scott');
INSERT [Customer] ([Id], [FirstName], [LastName]) VALUES (8790, 'Robert', 'Powers');

INSERT [Order] ([Id], [CustomerId], [TotalPaid], [DatePlaced]) VALUES (1026, 1228, 53.77, '2014-12-28');
INSERT [Order] ([Id], [CustomerId], [TotalPaid], [DatePlaced]) VALUES (1027, 1876, 12.54, '2015-01-02');
INSERT [Order] ([Id], [CustomerId], [TotalPaid], [DatePlaced]) VALUES (1030, 1876, 2.13, '2015-01-03');
INSERT [Order] ([Id], [CustomerId], [TotalPaid], [DatePlaced]) VALUES (1034, 1876, 16.54, '2015-01-16');
INSERT [Order] ([Id], [CustomerId], [TotalPaid], [DatePlaced]) VALUES (1041, 1876, 3.44, '2015-03-16');
INSERT [Order] ([Id], [CustomerId], [TotalPaid], [DatePlaced]) VALUES (1042, 1876, 67.76, '2015-03-18');
INSERT [Order] ([Id], [CustomerId], [TotalPaid], [DatePlaced]) VALUES (1049, 1876, 23.22, '2015-04-02');
INSERT [Order] ([Id], [CustomerId], [TotalPaid], [DatePlaced]) VALUES (1031, 2433, 1.95, '2015-01-04');
INSERT [Order] ([Id], [CustomerId], [TotalPaid], [DatePlaced]) VALUES (1033, 2433, 101.54, '2015-01-12');
INSERT [Order] ([Id], [CustomerId], [TotalPaid], [DatePlaced]) VALUES (1035, 2433, 84.91, '2015-01-28');
INSERT [Order] ([Id], [CustomerId], [TotalPaid], [DatePlaced]) VALUES (1036, 2433, 92.45, '2015-02-06');
INSERT [Order] ([Id], [CustomerId], [TotalPaid], [DatePlaced]) VALUES (1040, 2433, 8, '2015-03-16');
INSERT [Order] ([Id], [CustomerId], [TotalPaid], [DatePlaced]) VALUES (1046, 2433, 23.32, '2015-03-28');
INSERT [Order] ([Id], [CustomerId], [TotalPaid], [DatePlaced]) VALUES (1050, 2433, 5.23, '2015-04-18');
INSERT [Order] ([Id], [CustomerId], [TotalPaid], [DatePlaced]) VALUES (1051, 2433, 9.76, '2015-05-02');
INSERT [Order] ([Id], [CustomerId], [TotalPaid], [DatePlaced]) VALUES (1038, 7765, 4.46, '2015-03-02');
INSERT [Order] ([Id], [CustomerId], [TotalPaid], [DatePlaced]) VALUES (1039, 7765, 7.56, '2015-03-06');
INSERT [Order] ([Id], [CustomerId], [TotalPaid], [DatePlaced]) VALUES (1048, 7765, 23.32, '2015-04-02');
INSERT [Order] ([Id], [CustomerId], [TotalPaid], [DatePlaced]) VALUES (1025, 7860, 17.45, '2014-12-20');
INSERT [Order] ([Id], [CustomerId], [TotalPaid], [DatePlaced]) VALUES (1028, 7860, 23.56, '2015-01-02');
INSERT [Order] ([Id], [CustomerId], [TotalPaid], [DatePlaced]) VALUES (1032, 7860, 8.98, '2015-01-05');
INSERT [Order] ([Id], [CustomerId], [TotalPaid], [DatePlaced]) VALUES (1023, 8790, 19.99, '2014-12-02');
INSERT [Order] ([Id], [CustomerId], [TotalPaid], [DatePlaced]) VALUES (1024, 8790, 18.01, '2014-12-06');
INSERT [Order] ([Id], [CustomerId], [TotalPaid], [DatePlaced]) VALUES (1029, 8790, 44.54, '2015-01-02');
INSERT [Order] ([Id], [CustomerId], [TotalPaid], [DatePlaced]) VALUES (1037, 8790, 23.11, '2015-02-27');
INSERT [Order] ([Id], [CustomerId], [TotalPaid], [DatePlaced]) VALUES (1043, 8790, 123.54, '2015-03-26');
INSERT [Order] ([Id], [CustomerId], [TotalPaid], [DatePlaced]) VALUES (1044, 8790, 3.33, '2015-03-26');
INSERT [Order] ([Id], [CustomerId], [TotalPaid], [DatePlaced]) VALUES (1045, 8790, 65.66, '2015-03-28');
INSERT [Order] ([Id], [CustomerId], [TotalPaid], [DatePlaced]) VALUES (1047, 8790, 22.15, '2015-04-02');

commit