# CSharpProCourse
C# Professional course team project

Добавлен yaml для установки PostgreSQL в Docker.
Для развертывания необходимо выполнить команду в папке где находится файл:
<li>docker-compose -f postgre.local.yaml up</li>

Креды для поключения к БД
<li>Сервер: localhost:5432</li>
<li>Имя пользователя: postgres</li>
<li>Пароль: postgres</li>
<li>Название БД: customer_service.local</li>

Вместе с БД в контейнере находится pgAdmin
Его Web интерфес находится по адресу
<li>http://localhost:5555/</li>

Для входа необходимо ввести 
<li>Email: pgadmin4@pgadmin.org</li>
<li>Пароль: admin</li>

Так как Postgre и pgAdmin находятся в обной сети, то для поключения к БД из pgAdmin адрес сервера нужно указать postgres

Команда для создания миграций
dotnet ef migrations add НАЗВАНИЕ_МИГРАЦИИ --project CustomerService.Infrastructure --startup-project CustomerService.Web --context AppDbContext

Команда для удаления миграции
dotnet ef migrations remove НАЗВАНИЕ_МИГРАЦИИ --project CustomerService.Infrastructure --startup-project CustomerService.Web --context AppDbContext

При старте проекта автоматически накатваются миграции