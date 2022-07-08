# Reserveringssysteem
![Logo C Sharp applicatie](ReservationSystem.Core/Assets/StoreLogo.scale-200.png)

Een reserveringssysteem ter eindopdracht voor het vak C#2

## Installatie

### Benodigdheden:

* XAMPP (of een lokaal gehost MySQL database)
* Microsoft Visual Studio 2022 (Specifiek .NET SDK 6.0 (plus runtime) + ASP.NET core + UWP SDK)

### Instructies

* Clone de github repository naar een folder naar keuze
* Voer de DB.sql queries uit binnen phpmyadmin of een ander databasemamager
* Open de solution binnen Visual Studio 2022
* Stel in dat beide projecten uitgevoerd worden wanneer deze gestart worden binnen visual studio
    * Dit is mogelijk door naar de solution te gaan in de solution explorer -> Properties/Eigenschappen -> Selecteer multiple startup projects -> zet beide projecten op start -> apply
* Start de MySQL service of start deze binnen XAMPP
* Druk op start binnen visual studio, wanneer dit succesvol gebeurt opent er de swagger pagina met API documentatie, alsmede de applicatie zelf. **LET OP!** Wanneer de swagger pagina gesloten word stoppen beide applicaties.
* Enjoy!

