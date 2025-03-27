
// Tworzenie statków

using cw02;

Ship ship1 = new Ship("Titanic", 5, 200, 30);
Ship ship2 = new Ship("Evergreen", 3, 150, 25);

// Tworzenie kontenerów
Container gasContainer = new GasContainer(5000, 2000, 2.5, 6, 10);
Container liquidContainer = new LiquidContainer(4000, 1500, 2.0, 6, true);
Container refrigeratedContainer = new RefrigeratedContainer(3000, 1800, 2.3, 6, "Bananas", 5);

// Załadowanie ładunku do kontenerów
gasContainer.Load(4000);
liquidContainer.Load(2000);
refrigeratedContainer.Load(2500);

// Załadowanie kontenerów na statek
ship1.LoadContainer(gasContainer);
ship1.LoadContainer(liquidContainer);
ship1.LoadContainer(refrigeratedContainer);

// Wyświetlenie informacji o statku
ship1.DisplayInfo();

// Rozładowanie kontenera
gasContainer.Unload();
        
// Przeniesienie kontenera między statkami
Ship.TransferContainer(ship1, ship2, gasContainer.SerialNumber);

// Zastąpienie kontenera na statku
Container newContainer = new GasContainer(4000, 1800, 2.0, 6, 8);
ship1.ReplaceContainer(liquidContainer.SerialNumber, newContainer);

// Usunięcie kontenera ze statku
ship1.RemoveContainer(refrigeratedContainer.SerialNumber);

// Wyświetlenie informacji o statkach po operacjach
ship1.DisplayInfo();
ship2.DisplayInfo();