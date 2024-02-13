Aplikacja ma za zadanie zarządzanie pracownikami (dla pracodawcy- admina) lub przeglądanie pracowników oraz ich szczegółów (dla zwykłego usera).

Dane: imię, nazwisko, pesel, stanowisko, oddział, data zatrudnienia, data zwolnienia

a) Wykorzystane Technologie :

.NET 7.0
Baza danych SQLite: Przetrzymuje dane dotyczące pracowników 
xUnit: Testy jednostkowe w xUnit, tak jak na zajęciach.

Dane admina do logowania: Email: tadeusz@employees.pl Hasło: Haslo23!

Dane użytkownika do logowania: Email: adam@employees.pl Hasło: Haselko23!

Proces Uruchomienia Aplikacji w Wersji Deweloperskiej:

Uruchom plik AspLab.sln w Visual Studio.

Wybierz lab3zadanie jako projekt startowy.

Usuń poprzednie migracje z EmployeeData (EmployeeData/Migrations/... ).

Usuń plik lub pliki employee.db (jeśli istnieją) z lokalizacji ( C:\Users\OEM\AppData\Local )

Kliknij prawym przyciskiem myszy na EmployeeData, otwórz w terminalu i wpisz kolejno podane komendy (oddzielone znakiem | ), aby wykonać migrację: dotnet tool install --global |  dotnet-ef  | dotnet ef migrations add InitialCreate | dotnet ef database update

Obok wybranego lab3zadanie kliknij zielony przycisk Play, by uruchomić aplikację.

Po uruchomieniu kliknij w zakładkę Employees.

Zaloguj się na konto admina lub użytkownika. (Jeżeli nie masz konta, to możesz takowe zarejestrować lecz będzie ono jako zwykły user).

Aplikacja pokazuje wszystkich zapisanych pracowników w bazie danych.

(admin) Aby dodać pracownika, kliknij "Add an Employee", a następnie wprowadź dane i wciśnij "Create".

(admin) Przy dodawaniu użytkownika, z dat, mamy do wyboru tylko date zatrudnienia.


(admin) Przy update użytkownika, z dat, mamy możliwość tez dodania też daty zwolnienia pracownika, jeżeli tego nie potrzeba to po prostu nie zaznaczamy opcji tego dotyczącej.
(admin) Aplikacja daje możliwość edycji, zobaczenia detali oraz usunięcia pracownika.

W widoku "Details" możemy podjerzeć informacje o pracowniku: imię, nazwisko, pesel, stanowisko, oddział, data zatrudnienia oraz data zwolnienia, a jeżeli nie został on zwolniony to widnieje informacja czy dalej pracuje.

Po kliknięciu w swoje imię na navbarze, mamy dostęp do opcji związanych z kontem. 

Unit testy napisane w xUnit, sprawdzają poprawność działania EmployeeController.
![scr1](https://github.com/TadeQQ/Lab-ASP.NET/assets/88510018/8986dfac-3a41-461d-b4b5-d839c2429128)
![scr2](https://github.com/TadeQQ/Lab-ASP.NET/assets/88510018/9152cd71-2ed2-4bf4-9eb0-1bcf0a6eb42d)
![scr3](https://github.com/TadeQQ/Lab-ASP.NET/assets/88510018/cfff496e-32fa-4429-8dd7-49c92424d6e3)
