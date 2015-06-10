# Zestaw D:  Scenariusz dla projektu Dices

Celem zadania jest przygotowanie aplikacji, która pozwala na odnotowywanie kolejnych wyników rzutu kością do gry dla wybranych zawodników. System symuluje rzut dwiema kościami. Każda kość jest sześcienna i symetryczna. Użytkownik ma możliwość wyboru użytkownika, dla którego losowany jest wynik kościami, pokazania historii jego rzutów i zapisania jej do pliku. Dodatkowo użytkownik ma możliwość wskazania użytkowników, którzy mogą oszukiwać losując trzy lub więcej razy z rzędu ten sam wynik na obu kościach.

Aplikacja jest skonstruowana w oparciu o podejście MVVM. O ile nie napisano inaczej, cały kod należy napisać w klasie odpowiadającej warstwie ViewModel. Warstwa View jest już zaimplementowana i nie powinna być zmieniana. W ramach implementacji klasy DiceViewModel należy dostarczyć brakujących składowych (właściwa część zadania). Tam, gdzie mowa o przeszukiwaniu należy użyć kwerendy LINQ.

Z projektem dostarczone są klasy:
* MyDispatcher – odpowiedzialna za wywołanie akcji przekazanej do metody RunOnUi na wątku głównym aplikacji (instancja jest dostarczona pod postacią interfejsu IDispatcher)
* MyCommand – odpowiedzialna za dostarczenie uproszczonej implementacji dla interfejsu System.Windows.Input.ICommand
* DiceResult – enumeracja zawierająca wszystkie możliwe rezultaty rzutu kością
* TwoDicesResult – klasa modelu do trzymania wyniku rzutu dwiema kościami
* UserInfo – klasa modelu do trzymania imienia użytkownika (właściwość Name) i kolekcji jego wyników (właściwość Results)

### Zadanie 1: Jako użytkownik chcę widzieć ekran ze wszystkimi dostępnymi funkcjami celem wybrania kart lub kolorów do obliczenia prawdopodobieństwa.

Kryteria oceny:
* Należy zaimplementować interfejs IDiceViewModel w klasie o nazwie DiceViewModel.
* Właściwości z metodami get/set wywołuje zdarzenie pochodzące z interfejsu INotifyPropertyChanged w momencie przypisania wartości.
* Kolekcja udostępniona we właściwości Players jest zainicjalizowana 4 użytkownikami (imiona dowolne).
* Domyślnie wybrany użytkownik SelectedPlayer jest ustawiony na pierwszy element z kolekcji Players.
* W klasie DiceViewModel należy utworzyć pole celem przechowywania ostatnio wylosowanego wyniku z obu kości (typ TwoDicesResult). Pole jest zainicjalizowane w konstruktorze.
* Właściwości FirstDiceResult i SecondDiceResult zwracają właściwości z w/w ostatniego wyniku odpowiednio First i Second

Wskazówki:
* Właściwości typu ICommand mogą być zaimplementowane za pomocą udostępnionej klasy MyCommand.

### Zadanie 2: Jako użytkownik chcę wybrać gracza i „rzucić” dla niego kościami, celem poznania liczby oczek.

Kryteria oceny:
* Należy utworzyć obiekt typu Random do generowania liczb pseudolosowych i utrwalić go w polu klasy DiceViewModel. Cykl życia tego obiektu jest taki sam jak DiceViewModel.
* Należy zaimplementować metodę odpowiadającą na wykonanie metody ThrowDicesForSelectedPlayerCommand.
* W metodzie należy:
  * Wygenerować dwie liczby całkowite za pomocą w/w generatora liczb pseudolosowych (metoda Next), które są w przedziale domkniętym od 1 do 6.
  * Wygenerowane liczby należy utrwalić w obiekcie typu TwoDicesResult, właściwościach odpowiednio First i Second
  * W/w obiekt powinien stać się wartością pola ostatniego wyniku. Ostatni wynik powinien pokazać się na ekranie.

Wskazówki:
* Można rzutować typ liczbowy na wartość enumeracji.
* Zdarzenie powiązane z interfejsem INotifyPropertyChanged może być uruchamiane nie tylko w momencie wywołania metody set dla właściwości.

### Zadanie 3: Jako użytkownik chcę zapisać wynik rzutu kością dla wybranego zawodnika celem późniejszej analizy.

Kryteria oceny:
* W ramach metody odpowiadającej na wywołanie akcji ThrowDicesForSelectedPlayerCommand  (zadanie 3) należy utrwalić obiekt z wynikami należy utrwalić w kolekcji rezultatów (Results) dla aktualnie zaznaczonego gracza (SelectedPlayer). 

### Zadanie 4: Jako użytkownik chcę zapisać na dysku kolekcję kolejnych rzutów dla wszystkich graczy.

Kryteria oceny:
* Należy zaimplementować metodą odpowiadającą na wykonanie komendy SaveResultsCommand.
* Zawartość kolekcji, w której zapamiętane są słowa kluczowe (patrz Zadanie 3) jest zapisana w pliku tymczasowym i formacie XML.

Wskazówki:
* Do implementacji zapisu do formatu XML można użyć dodatkowej biblioteki dostarczonej w ramach środowiska .NET. Należy pamiętać o istnieniu wielu konstruktorów i wybrać najbardziej odpowiadający potrzebom przechowywania obiektów wielu typów.
* Operacje wejścia/wyjścia są zabiegami czasochłonnymi. Należy mieć to na uwadze implementując rozwiązanie.

### Zadanie 5: Jako użytkownik chcę spośród dokonanych rzutów wyszukać użytkowników którzy 3 lub więcej razy z rzędu wyrzucili taką samą liczbę oczek na obu kostkach.

Kryteria oceny:
* Należy zaimplementować metodą odpowiadającą na wykonanie komendy ShowMeCheatersCommand.
* Za pomocą wyrażenia LINQ należy wskazać tych graczy z kolekcji Players, gdzie w rezultatach (właściwość Results) występuje 3 lub więcej elementowy ciąg wyników rzutów o takich samych wynikach na obu kostkach (właściwości First i Second)
* Znalezione elementy powinny być utrwalone w postaci listy, w kolekcji dla właściwości Cheaters, a wynik powinien pojawić się na ekranie.

