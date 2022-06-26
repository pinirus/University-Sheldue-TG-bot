# Описание проекта

### **Идея проекта:**
#### Приложение для уведомлений студента о парах.

### **Описание:**
#### Цель этого приложения уведомлять студентов до начала пары, та уточнять её домашнее задание и указывать его приоритет.

# Составные части

### Проект составляет из себя 3 основные части:

#### Backend - сервер для храения, получения, отправки данных

	- DAL - слой доступа до данных (модели, подключение к базе данных MS SQL через EF,
	использование UOW, Repository)
    - BLL - сервисы бизнес логики для работы з данными (фасад работы з DAL, (уведомления???))
	- API - ASP.NET API работающего через REST запросы (??)  

#### Frontend - пользовательские интерфейсы

	- СSLib - С# библиотека для работы с API (Паттерны и архитектура??)
    - WPFDesktop - WPF windows приложение для использования проекта (Паттерны и архитектура??)
	- BlazorWebApp - Сайт для использования проекта (Паттерны и архитектура??)
	- TelegramBot - бот для использования проекта (Паттерны и архитектура??)

#### NUnit Тесты - тестированние
	- ...

# Описание модулей

## **Backend**

### API (в разработке...)

#### Get all items 

```http
  GET /api/items
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `api_key` | `string` | **Required**. Your API key |

#### Get item

```http
  GET /api/items/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **Required**. Id of item to fetch |

#### add(num1, num2)

Takes two numbers and returns the sum.


### BLL


### DAL - слой доступа до данных 

![Screenshoot](https://raw.githubusercontent.com/eugene-gryn/University-Sheldue-TG-bot/changes/Diagrms/DAL.png)
Рис. Диаграмма классов DAL. Тут использованны паттерны Repository, UOW
и сделанная фабрика на все опции подключения к БД

![App](https://raw.githubusercontent.com/eugene-gryn/University-Sheldue-TG-bot/changes/Diagrms/Models.png)
Рис. Тут изображена диаграмма моделей классов проекта.
Пользователь может иметь несколько групп, каждая группа имеет свое расписание и предметы.
Пользователь имеет свое личное домашнее задание, которое ссылается на предмет из определенной
группы. Каждая группа имеет свой набор пар. И каждый пользователь имеет свои настройки
уведомлений. Группа имеет создателя, список редакторов и список обычных пользователей.
Пара имеет ссылку на предмет и имеет срок начала и конца. Сам предмет имеет свою группу,
и разная информация про него самого (название предмета, учитель и место его проведения).
Имеет ссылку на гугл мит, которая приходит перед самой парой, и которую можно указать.


![App Screenshot](https://raw.githubusercontent.com/eugene-gryn/University-Sheldue-TG-bot/changes/Diagrms/EF.png)
Рис. Тут основное внимание стоит сфокусировать на т.н "Фабрику опций", которая имеет
абстрактный класс, который конфигурирует различные способы подключения к БАЗЕ Данных
в любом из слоев возможно наследование от этого класса, чтобы настроить опции под определенный
под определенный тип подключения (для этого ещё добавленны Repository & UOW)

## **Frontend**



### СSLib


### WPFDesktop


### BlazorWebApp


### TelegramBot




# Функционал программы

### **Фукнции проекта** 0.2(beta)
	- Пользователь
		- Логин
			- При регистрации создать (уникальный у всех) (без возможности изменить)
		- Имя
			- Установить при регистрации
			- Поменять (после регистрации)
		- Аватар *(не объязательно)
			- Установка по умолчанию (картинка)
			- Обновить (файл на сервере)
		- Пароль
			- При регистрации устновить
			- Возможность поменять (подтверждение через тг бота)
		- Администраторские права
			- Один администратор может повысить другого
			- Один администратор может удалить другого
		- Настройки (автозначения - все) (включить\выключить)
			- Присылать ли уведомления до пары?
			- Присылать ли уведомления про пару?
			- Присылать ли уведомления про домашнее задание после пары?
			- Присылать ли уведомления про срок домашнего задания?
			- Присылать ли уведомления про срыв срока домашнего задания?
		- Возможности
			- Зарегистрировать нового пользователя
			- Зайти под существующим логином и паролем
			- Возможность выключить одно из уведомлений
			- Возможность включить одно из уведомлений
			- Возможность выключить сразу все
			- Возможность включить сразу все

	- Пользователь администратор
		- Назначение администраторов
			- Один администратор может повысить другого
			- Один администратор может удалить другого
		- Управление пользователями
			- Получение списка всех пользователей
			- Изменение информации про пользователя
			- Удаления профиля пользователя


	- Управление домашними заданиями пользователей
		- Содержание самого дз
			- Описание
				- Возможность изменить
			- Дэдлайн
				- Возможность переназначить выполнение на другой срок (не раньше сегодня)
			- Предмет по которому дз
				- Изменить предмет с дз
			- Приоритет
				- Возможность изменить приоритет
		- Операции
			- (Пользователь)
				- Создать дз
				- Получить список всех заданий (с предметом)
				- Получить задание по его айди
				- Смена данных про дз
				- Удаление(выполнение) дз
			- (Администратор)
				- Получение списка всех дз одного пользователя
				- Удаление по айди
	


	- Управление группами 
		- (Пользователь)
			- Получить публичный список(10) - Групп наиболее соотвествующих названию
			- Вступить в группу по названию (публичная)
			- Создать группу (публичную или приватную)
			- Получить информацию про группу (без списков пользователей)
			- Получить список пар
			- Получить отдельную пау по айди
			- Получить ближайшею пару
			- Получить список пар на определенный день
			- Получить список предметов группы
			- Выйти с группы
		- (Админ)
			- Получить список всех групп (даже приватных)
			- Получить информацию про группу по айди (со всеми списками)
		- (Админ и Создатель)
			- Изменить Создателя группы
			- Назначить новых модераторов из уже вступивщих пользователей
			- Удалить группу (у всех пользователей удаляется дз с группы)
		- (Админ или Модер, Создатель)
			- Изменить имя группы
			- Изменить приватность группы
			- Удалить пользователя 
			  	(удаляется все дз который были связанны с предметами группы)
			- Добавление всем пользователям дз связанного с предметом этой группы
			- Доабвить пару (проверка на колизию)
			- Изменить пару
			- Удалить пару
			- Удалить все пары
			- Добавить новый предмет
			- Удалить существующий предмет 
			  	(у всех пользователей группы удаляется дз связанно с ним)
			- Удалить все предметы группы
				(у всех пользователей группы удаляется дз связанно с ним)
			- Загрузка рассписания
				- Excel загрузка
					- Загрузка через Excel файл определенного формата
				- PDF загрузка
					- Загрузка готового рассписания с сайта


