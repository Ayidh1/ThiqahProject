-- create table
CREATE TABLE [Imports](
	[نوع المنفذ] [nvarchar](255) NULL,
	[السنة] [nvarchar](255) NULL,
	[قيمة الواردات] [float] NULL
);

-- insert

INSERT INTO Imports VALUES ('railway', '2008', 179172254)
;
INSERT INTO Imports VALUES ('railway', '2009', 16354207270.4296)
;
INSERT INTO Imports VALUES ('railway', '2010', 17599851049.0478)
;
INSERT INTO Imports VALUES ('railway', '2011', 21594084125.3778)
;
INSERT INTO Imports VALUES ('railway', '2012', 20245633839.7556)
;
INSERT INTO Imports VALUES ('railway', '2013', 22454067505.2919)
;
INSERT INTO Imports VALUES ('railway', '2014', 25751681540.1716)
;
INSERT INTO Imports VALUES ('railway', '2015', 29071258309.1396)
;
INSERT INTO Imports VALUES ('railway', '2016', 23850387276.5394)
;
INSERT INTO Imports VALUES ('railway', '2017', 23954038713.6202)
;
INSERT INTO Imports VALUES ('railway', '2018', 23616529162.119)
;
INSERT INTO Imports VALUES ('post office', '2008', 1051495)
;
INSERT INTO Imports VALUES ('post office', '2009', 111301710)
;
INSERT INTO Imports VALUES ('post office', '2010', 106487642)
;
INSERT INTO Imports VALUES ('post office', '2011', 89128573)
;
INSERT INTO Imports VALUES ('post office', '2012', 104653984)
;
INSERT INTO Imports VALUES ('post office', '2013', 102273902)
;
INSERT INTO Imports VALUES ('post office', '2014', 80427813)
;
INSERT INTO Imports VALUES ('post office', '2015', 83451161)
;
INSERT INTO Imports VALUES ('post office', '2016', 47503024)
;
INSERT INTO Imports VALUES ('post office', '2017', 47469343)
;
INSERT INTO Imports VALUES ('post office', '2018', 31538933)
;
INSERT INTO Imports VALUES ('sea port', '2008', 3422858814.5157)
;
INSERT INTO Imports VALUES ('sea port', '2009', 233974638354.781)
;
INSERT INTO Imports VALUES ('sea port', '2010', 263451746378.256)
;
INSERT INTO Imports VALUES ('sea port', '2011', 327489957058.188)
;
INSERT INTO Imports VALUES ('sea port', '2012', 412563072774.972)
;
INSERT INTO Imports VALUES ('sea port', '2013', 424706755020.967)
;
INSERT INTO Imports VALUES ('sea port', '2014', 428220145405.304)
;
INSERT INTO Imports VALUES ('sea port', '2015', 413197918359.352)
;
INSERT INTO Imports VALUES ('sea port', '2016', 331952525982.179)
;
INSERT INTO Imports VALUES ('sea port', '2017', 313016745645.179)
;
INSERT INTO Imports VALUES ('sea port', '2018', 320608004049.155)
;
INSERT INTO Imports VALUES ('land port', '2008', 406320783.1498)
;
INSERT INTO Imports VALUES ('land port', '2009', 48134729497.1799)
;
INSERT INTO Imports VALUES ('land port', '2010', 57203833807.7526)
;
INSERT INTO Imports VALUES ('land port', '2011', 67905815194.1386)
;
INSERT INTO Imports VALUES ('land port', '2012', 75593336929.2818)
;
INSERT INTO Imports VALUES ('land port', '2013', 80276882157.8817)
;
INSERT INTO Imports VALUES ('land port', '2014', 81329418904.8527)
;
INSERT INTO Imports VALUES ('land port', '2015', 81892822905.959)
;
INSERT INTO Imports VALUES ('land port', '2016', 65793938725.4344)
;
INSERT INTO Imports VALUES ('land port', '2017', 57916490228.8647)
;
INSERT INTO Imports VALUES ('land port', '2018', 55231145108.4225)
;
INSERT INTO Imports VALUES ('air port', '2008', 497437628.7073)
;
INSERT INTO Imports VALUES ('air port', '2009', 59849647180.1822)
;
INSERT INTO Imports VALUES ('air port', '2010', 66134156089.1175)
;
INSERT INTO Imports VALUES ('air port', '2011', 79084261247.4754)
;
INSERT INTO Imports VALUES ('air port', '2012', 93394644775.0995)
;
INSERT INTO Imports VALUES ('air port', '2013', 114163071864.623)
;
INSERT INTO Imports VALUES ('air port', '2014', 124882209896.291)
;
INSERT INTO Imports VALUES ('air port', '2015', 137284205300.822)
;
INSERT INTO Imports VALUES ('air port', '2016', 106615996233.491)
;
INSERT INTO Imports VALUES ('air port', '2017', 110699576352.887)
;
INSERT INTO Imports VALUES ('air port', '2018', 118262509197.275)
;

-- SELECT Statment 
-- select * from Imports

-- Complete the code 

-- Create a view of Imports
CREATE VIEW ImportsView AS SELECT [نوع المنفذ] AS PortType, [السنة] AS Year, [قيمة الواردات] AS ImportValue FROM Imports;

-- Answer for Q1 of Part 2.2 "Find The largest import value and its type"
SELECT PortType, max(ImportValue) FROM ImportsView;

-- Answer for Q2 of Part 2.2 "Find the total importing value per Port Type"
SELECT PortType, sum(ImportValue) FROM ImportsView GROUP BY PortType;

-- Answer for Q3 of Part 2.2 "Find the least importing value and its type"
SELECT PortType, min(ImportValue) FROM ImportsView;

-- Answer for Q4 of Part 2.2 "Show the data with ascending Importing value"
SELECT PortType, Year, ImportValue FROM ImportsView ORDER BY ImportValue ASC;

-- Answer for Q5 of Part 2.2 "Find some extra insights"
-- "Find the largest import value and its Port Type per Year"
SELECT PortType, Year, max(ImportValue) FROM ImportsView GROUP BY Year;
-- "find the total importing value and its Port Type per Year"
SELECT PortType, Year, sum(ImportValue) FROM ImportsView GROUP BY Year,PortType;
-- "find the least and largest importing value per Port Type"
SELECT PortType, min(ImportValue), max(ImportValue) FROM ImportsView GROUP BY PortType;