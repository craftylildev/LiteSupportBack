use LiteSupportDb 

INSERT INTO Customer (FirstName, LastName, Company, URL, Phone, Email) VALUES ('Joe', 'Smith', 'JSCompany', 'http://www.joesmithco.com', '615-555-1234', 'jsmith@joesimthco.com' );
INSERT INTO Customer (FirstName, LastName, Company, URL, Phone, Email) VALUES ('Jane', 'Doe', 'JDDesigns', 'http://www.jddesigns.com', '615-555-1235', 'jane@jddesigns.com' );

INSERT INTO Department (DepartmentName) VALUES ('Support');
INSERT INTO Department (DepartmentName) VALUES ('Design');
INSERT INTO Department (DepartmentName) VALUES ('Development');

INSERT INTO Employee (FirstName, LastName, DepartmentId, Email, Phone) VALUES ('Jim', 'Johnson', 1, 'jimj@gmail.com', '615-555-1000');
INSERT INTO Employee (FirstName, LastName, DepartmentId, Email, Phone) VALUES ('Andy', 'Miller', 3, 'andym@gmail.com', '615-555-3000');
INSERT INTO Employee (FirstName, LastName, DepartmentId, Email, Phone) VALUES ('Jen', 'Solima', 2, 'jensolima@gmail.com', '615-555-2000');

INSERT INTO Ttype (TtypeName) VALUES ('Bug Fix');
INSERT INTO Ttype (TtypeName) VALUES ('Design Request');

INSERT INTO Priority (PriorityName) VALUES ('Low');
INSERT INTO Priority (PriorityName) VALUES ('Medium');
INSERT INTO Priority (PriorityName) VALUES ('High');
