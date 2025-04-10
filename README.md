# Personal Finance Tracker (Správce osobních financí)

Jednoduchá desktopová aplikace v C# (Windows Forms) pro sledování osobních příjmů a výdajů.

## Popis

Tato aplikace umožňuje uživatelům zaznamenávat své finanční transakce (příjmy a výdaje), kategorizovat je a sledovat aktuální zůstatek. Využívá MySQL databázi pro ukládání dat.

## Funkce

*   **Přidání transakce:** Možnost zadat datum, typ (Příjem/Výdej), částku, kategorii a popis transakce.
*   **Zobrazení transakcí:** Přehledný seznam všech transakcí v tabulce (DataGridView).
*   **Úprava transakce:** Možnost upravit existující transakci (dvojklikem na řádek v tabulce).
*   **Smazání transakce:** Možnost odstranit vybranou transakci.
*   **Správa kategorií:** Transakce lze přiřadit k předdefinovaným kategoriím (načítaným z databáze).
*   **Zobrazení zůstatku:** Aplikace automaticky vypočítává a zobrazuje aktuální finanční zůstatek.

## Technologie

*   C# (.NET Framework)
*   Windows Forms (WinForms) pro GUI
*   MySQL databáze pro ukládání dat
*   MySql.Data connector pro komunikaci s databází

## Instalace a spuštění

1.  **Databáze:**
    *   Nainstalujte MySQL server (např. pomocí XAMPP).
    *   Vytvořte databázi (např. s názvem `personal_finance`).
    *   Importujte strukturu tabulek a základní data pomocí přiloženého souboru `Databáze/personal_finance.sql`.
    *   Upravte připojovací řetězec (connection string) v souboru `App.config` tak, aby odpovídal vaší konfiguraci MySQL (server, databáze, uživatel, heslo). Výchozí nastavení v `App.config` může vypadat například takto:
        ```xml
        <connectionStrings>
          <add name="DefaultConnection" connectionString="server=localhost;database=personal_finance;uid=root;pwd=;" providerName="MySql.Data.MySqlClient"/>
        </connectionStrings>
        ```

2.  **Aplikace:**
    *   Otevřete projekt (`PersonalFinanceTracker.sln`) ve Visual Studiu.
    *   Obnovte NuGet balíčky (zejména `MySql.Data`).
    *   Sestavte (Build) projekt.
    *   Spusťte aplikaci (Start).

## Závislosti

*   .NET Framework (verze specifikovaná v `.csproj` souboru)
*   MySQL Server
*   MySql.Data NuGet balíček

## Poznámky

*   Aplikace předpokládá existenci databáze a správně nakonfigurovaný připojovací řetězec v `App.config`.
*   Kód pro interakci s databází je umístěn v souboru `DatabaseHelper.cs`.
*   GUI a logika formuláře jsou v souborech `Form1.cs` a `Form1.Designer.cs`.
