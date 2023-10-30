import os
import random
import time
import keyboard


# Wczytanie danych z pliku
def load_data(filename):
    data = []
    with open(filename, 'r', encoding='utf-8') as file:
        for line in file:
            line = line.strip().split(',')
            data.append((line[0], line[1]))
    return data

def on_key_release(key):
    print("Klawisz został naciśnięty!")
    listener.stop()

# Główna funkcja programu
def main():
    data = load_data("slowa.txt")  # Zmień nazwę pliku na nazwę swojego pliku z danymi
    language_choice = input("Wybierz język (polski/angielski): ").lower()

    if language_choice not in ['polski', 'angielski']:
        print("Niepoprawny wybór języka.")
        time.sleep(2)
        return
    os.system('cls')
    punkty = 0
    tura = 0
    bledne_odpowiedzi = 0
    maxPunktow = len(data)
    while data:
        tura += 1
        word_pair = random.choice(data)
        if language_choice == 'polski':
            word = word_pair[0]
            translation = word_pair[1]
        else:
            word = word_pair[1]
            translation = word_pair[0]

        user_translation = input(f"Przetłumacz słowo '{word}': ")

        if user_translation == translation:
            print("Poprawna odpowiedź! Usuwam słowo z listy.")
            data.remove(word_pair)
            time.sleep(1)
            punkty += 1
        else:
            bledne_odpowiedzi += 1
            print("Niepoprawna odpowiedź. Spróbuj jeszcze raz i naciśnij spacje jak będziesz gotowy.")
            print(f"Poprawne słowo to: {translation}.")
            keyboard.wait('space')
        os.system('cls')
    print("Wszystkie słowa zostały przetłumaczone.")
    print(f"Zdobyłeś {punkty} punktów w {tura} próbach, a to daje ocenę ", end="")
    ocena_procentowa = (punkty**1.5 / tura**1.5) * 100
    if ocena_procentowa >= 95:
        print("6")
    elif ocena_procentowa >= 90:
        print("6-")
    elif ocena_procentowa >= 85:
        print("5+")
    elif ocena_procentowa >= 80:
        print("5")
    elif ocena_procentowa >= 75:
        print("5-")
    elif ocena_procentowa >= 70:
        print("4+")
    elif ocena_procentowa >= 65:
        print("4")
    elif ocena_procentowa >= 60:
        print("4-")
    elif ocena_procentowa >= 55:
        print("3+")
    elif ocena_procentowa >= 50:
        print("3")
    elif ocena_procentowa >= 45:
        print("3-")
    elif ocena_procentowa >= 40:
        print("2+")
    elif ocena_procentowa >= 35:
        print("2")
    elif ocena_procentowa >= 30:
        print("2-")
    elif ocena_procentowa >= 25:
        print("1+")
    else:
        print("1")
    time.sleep(5)

main()
