<h1>lims</h1>
<p>Пример проектирования приложения с микросервисной архитектуры с учётом highload</p>
<p>Прототип микросервиса. В папке /data диаграммы, ТЗ, решение</p>

<p>Создание таблицы:</p>
CREATE TABLE Samples (
    Id int NOT NULL  IDENTITY(1,1) PRIMARY KEY,
    Name varchar(255) NOT NULL,
    Code varchar(255) NOT NULL
);
