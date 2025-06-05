# BookReviewsApp - L. Vuran

Aplikacija za kolegij Razvoj web aplikacija u ASP.NET MVC tehnologiji ak. god. 2024/25

Aplikacija omogućuje korisniku registraciju i prijavu na forum s osvrtima. Korisnik može kreirati, urediti i obrisati vlastite osvrte te može ostavljati komentare ispod svih osvrta.
Također je omogućeno dodavanje korisničkih tagova koji omogućavaju filtriranje svih unesenih osvrta. Tag je omogućen za odabrati samo korisniku koji ga je kreirao, ali filtraciju može napraviti bilo tko. Moguće je i uređivanje i podataka o korisniku.
Implementiran je API za CRUD operacije nad Review objektima.

# Funkcionalnosti

## Smislenost objektnog modela
Da li objekti imaju smisla (minimalno 4 entity framework klase, ne racunajuci User) - DA (Review, Tag, Comment, Genre, AppUser)

Da li tipovi podataka u objektima imaju smisla (datumi, nullable gdje treba, int vs string, ..) -DA

Da li su naznačene ispravne veze među objektima (1-N, N-N, nasljeđivanje) - DA

## MVC Routing i URL prostori
Da li postoji kompletni izbornik u aplikaciji? - DA (Discover, Profile, Add Rewiew)

Postoji li custom ruta definirana u RouteConfig-u? (recimo, /kompanije/pregled i sl.) - DA (/add-new)

Da li postoji ruta definirana atributima/anotacijama? - DA (my-profile)


## CRUD operacije i osnovni koncepti rukovanja entitetima
Da li je kroz aplikaciju moguće izmjeniti podatke za barem 2 entiteta (ovisno o poslovnim pravilima) - DA (Review, AppUser)

Postoji li zajednicki partial view na edit+create formi? - DA

Postoji li validacija (server side) - DA

Postoji li validacija (client side) - DA

Drop down liste (unos vezanih vrijednosti obvezno preko drop down liste) - DA

Postoji li seed za unos nekih inicijalnih vrijednosti (primjerice, gradovi i slično) - DA (Genre)

Jesu li ispravno implementirane migracijske skripte (postoji li initial i bar jos jedna migracija) - DA

Postoje li barem 3 elementa na sučelju implementirani pomoću Tag Helper-a? - DA

Postoji li datumska kontrola i funkcionira li na barem 2 jezika s različitim formatom datuma? - DA

Je li korisničko sučelje napravljeno slijeđenjem osnovnih bootstrap principa? - DA

## Organizacija aplikacije
Postoji li DAL i model sloj? - DA

Jesu li ispravni elementi u svakom sloju? - DA

## Autorizacija i autentikacija
Da li je moguće registrirati korisnika (obično + jedan od servisa kao što je google ili FB)? - Običan login je omogućen

## Web API
Postoji li mogućnost dohvata barem jednog tipa entiteta putem API-ja? (lista, preko id-a) - DA (/api/review)

Postoji li mogućnost dodavanja, izmjene i brisanja barem jednog entiteta putem API-ja? - DA

# Funkcionalnosti koje nisu implementirane

## CRUD operacije i osnovni koncepti rukovanja entitetima

Postoji li forma za pretraživanje koja koristi AJAX za dohvat rezultata? - NE

Postoji li "delete" implementiran pomoću AJAX poziva? - NE

## Autorizacija i autentikacija

Da li je implementiran Owin model?

Postoje li odvojene role za neke dijelove aplikacije?

Da li je Owin model ukombiniran sa vlastitom bazom?

Da li je moguće registrirati korisnika (obično + jedan od servisa kao što je google ili FB)? - Servisi nisu implementirani

