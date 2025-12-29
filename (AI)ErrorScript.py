import requests
import sqlite3
from bs4 import BeautifulSoup

DB_PATH = r"E:\Databases Local\Baum.db"

# -------------------------
# DB VERBINDUNG
# -------------------------
conn = sqlite3.connect(DB_PATH)
cur = conn.cursor()

# -------------------------
# POKÉMON OHNE EINTRAG LADEN
# -------------------------
cur.execute("""
    SELECT PokedexID, DName
    FROM PokemonData
    WHERE Eintrag = "Kein Eintrag vorhanden"
""")

rows = cur.fetchall()

print(f"🔎 {len(rows)} Pokémon ohne Pokédexeintrag gefunden")

# -------------------------
# DURCHGEHEN
# -------------------------
for pokedex_id, dname in rows:
    print(f"\n➡️ {pokedex_id:03} – {dname}")

    url = f"https://www.bisafans.de/pokedex/{pokedex_id:03}.php#pokedex"

    try:
        response = requests.get(url, timeout=10)
        response.raise_for_status()
    except Exception as e:
        print(f"❌ Fehler beim Laden der Seite: {e}")
        continue

    soup = BeautifulSoup(response.text, "html.parser")

    # -------------------------
    # ABSCHNITT FINDEN
    # -------------------------
    headline = soup.find("h3", string="Pokédexeinträge")
    if not headline:
        print("❌ Abschnitt 'Pokédexeinträge' nicht gefunden")
        continue

    ul = headline.find_next("ul", class_="list-group")
    if not ul:
        print("❌ Liste mit Pokédexeinträgen nicht gefunden")
        continue

    entries = []

    for li in ul.find_all("li", class_="list-group-item"):
        # PLZA / Editionslabel entfernen
        for a in li.find_all("a"):
            a.decompose()

        text = li.get_text(" ", strip=True)

        if not text or "Kein Eintrag vorhanden" in text:
            continue

        entries.append(text)

    if not entries:
        print("⚠️ Keine gültigen Einträge gefunden")
        continue

    final_text = "\n".join(dict.fromkeys(entries))

    # -------------------------
    # UPDATE
    # -------------------------
    cur.execute(
        """
        UPDATE PokemonData
        SET Eintrag = ?
        WHERE PokedexID = ?
        """,
        (final_text, pokedex_id)
    )

    conn.commit()
    print("✅ Eintrag gespeichert")

# -------------------------
# AUFRÄUMEN
# -------------------------
conn.close()
print("\n🏁 Fertig")
