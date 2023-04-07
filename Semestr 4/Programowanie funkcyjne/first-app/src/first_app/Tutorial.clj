(ns first-app.Tutorial
  (:require [clojure.string :as str])  ;; potrzebne do operacji na stringach
  (:gen-class))





; --- ---[ Variables and Data Types ]--- --- 

(def randVar 10) ; w ten sposób możemy zdefiniwać stałą
(type false) ; w clojure mamy również typy bool

(def aLong1 15)
(nil? aLong1) ; nil? sprawdza czy liczba ma wartość (jeśli ma, to zwracany jest false)

; Możemy sprawdzać czy coś jest danym typem
(pos? 15) ; dodatnia?
(neg? -15) ; ujemna?
(even? 2) ; parzysta?
(odd? 1) ; nieparzysta?
(integer? 15) ; całkowita?


; --- ---[ Formatted Output ]--- --- 

(def aString "Hello")
(def aDouble 1.234)
(def aLong2 15)
(format "This is string %s" aString) ;; "This is string Hello"
(format "5 spaces and %5d" aLong2) ;; "5 spaces and    15"
(format "Leading zeros %04d" aLong2) ;; "Leading zeros 0015"
(format "%-4d left justified" aLong2) ;; "15   left justified"
(format "3 decimals %.3f" aDouble) ;; "3 decimals 1,233"


; --- ---[ Strings ]--- --- 

(def str1 "This is my 2nd string")
(str/blank? str1) ; do sprawdzenia czy string jest pusty potrzebujemy biblioteki? (:require [clojure.string :as str])
(str/includes? str1 "my") ; sprawdzenie czy jest substring
(str/index-of str1 "my") ; na ktorym indexie wystepuje "my"
(str/split str1 #" ") ; rozdzielamy string na tablice stringow
(str/split str1 #"\d") ; rozdzielanie poprzez liczby
(str/join " " ["The" "Big" "Cheese"]) ; laczenie stringow
(str/replace "I am 42" #"42" "43") ; zmiana danego elementu
(str/upper-case str1) ; zmiana na wielkie litery
(str/lower-case str1) ; zmiana na male litery


; --- ---[ Lists ]--- --- 

(println (list "Dog" 1 3.4 true)) ; wyswietl elementy listy
(println (first (list 1 2 3))) ; wyswielt pierwszy element listy
(println (nth (list 1 2 3) 2)) ; wyswietl element na indexie 2
(println (list* 1 2 [3 4])) ; dodaj elementy 3 i 4 do listy
(println (cons 3 (list 1 2))) ; dodaj wartość na początek listy


; --- ---[ Sets (listy o unikalnych wartościach )]--- --- 

(println (set '(1 1 2))) ; otrzymamy {1 2}
(println (get (set '(3 2)) 3)) ; wyswietl z seta konkretna wartosc
(println (conj (set '(3 2)) 1)) ; dodaj element do seta na poczatku
(println (contains? (set '(3 2)) 2)) ; sprawdz czy  set zawiera element


; --- ---[ Vectors ]--- --- 

(println (get (vector 3 2) 0)) ; wyswietl z vectora wartos na indexie 0
(println (pop (vector 3 2 7))) ; usun ostatnia wartosc z vectora i zwroc vector bez niej
(println (subvec (vector 1 2 3 4) 1 3))


; --- ---[ Maps (klucz - wartość) ]--- --- 

(println (hash-map "Name" "Derek" "Age" 42)) ; {Age 42, Name Derek}
(println (sorted-map 3 42 2 "Banas" 1 "Derek")) ; {1 Derek, 2 Banas, 3 42}
(println (get (hash-map "Name" "Derek" "Age" 42) "Name")) ; zwroc wartosc na podstawie klucza
(println (find (hash-map "Name" "Derek" "Age" 42) "Name")) ; [Name Derek]
(println (contains? (hash-map "Name" "Derek" "Age" 42) "Age")) ; sprawdz czy mapa zawiera KLUCZ
(println (keys (hash-map "Name" "Derek" "Age" 42))) ; zwroc wszystkie klucze mapy
(println (vals (hash-map "Name" "Derek" "Age" 42))) ; zwroc wszystkie wartosci mapy
(println (merge-with + (hash-map "Name" "Derek") (hash-map "Age" 42))) ; polacz mapy ze soba


; --- ---[ Atoms (dzieki nim mozemy zmienic wartosc zmiennej) ]--- --- 

(defn atom-ex
  [x]

  (def atomEx (atom x))

  (add-watch atomEx :watcher
    (fn [key atom old-state new-state]
      (println "atomEx changed from "
               old-state " to " new-state)))
  
  (println "1st x" @atomEx)
  (reset! atomEx 10)
  (println "2nd x" @atomEx)
  (swap! atomEx inc)
  (println "Increment x" @atomEx)
)

(atom-ex 5)




; --- ---[ Agents (zmiana wartości wykorzystując funkcje) ]--- --- 

(defn agent-ex
  []
  
  (def tickets-sold (agent 0))
  (send tickets-sold + 15)
  (println)
  (println "Tickets " @tickets-sold)

  (send tickets-sold + 10)
  (await-for 100 tickets-sold)
  (println "Tickets " @tickets-sold)

  (shutdown-agents)
  )

(agent-ex)



; --- ---[ Math ]--- --- 

(println (mod 12 5)) ; reszta z dzielenia

(println (inc 5)) ;; Increment
(println (dec 5)) ;; Decrement

(println (Math/abs -10)) ;; wartosc bezwzgledna
(println (Math/cbrt 8)) ;; pierwiastek szescienny
(println (Math/sqrt 4)) ;; pierwiastek kwadrwatowy
(println (Math/ceil 4.5)) ;; zaokraglij w gore
(println (Math/floor 4.5)) ;; zaokraglij w dol
(println (Math/max 1 5)) ;; wartosc maksymalna
(println (Math/min 1 5)) ;; wartosc minimalna
(println (Math/pow 2 2)) ;; potegowanie

(println (rand-int 20)) ;; losowa liczba calkowita 1 - 19

(println (reduce + [1 2 3])) ;; operacje na kolekcji w tym wypadku dodawanie



; --- ---[ Basic Functions ]--- --- 

(defn say-hello  ;; nazwa funkcji
  "Receives a name with 1 parameter and responds" ;; opis funkcji
  [name] ;; parametry funkcji
  
  (println "Hello again " name) 
  )

;; przeciazenie funkcji i wywolanie na podstawie ilosci parametrow
(defn get-sum
  ([x y z]
  (+ x y z))

  ([x y]
  (+ x y)))

(defn hello-you
  [name]
  
  (str "Hello " name))

;; mapowanie funkcji hello you na wszystkie elementy listy
(defn hello-all
  [& names]
  (map hello-you names)) 

(hello-all "Me" "You")



; --- ---[ Relational Operators ]--- --- 

;; =   
;; not=
;; < > >= <=
(not= 4 5)
(and true false)
(or true false)
(not true)



; --- ---[ If Else When ]--- --- 

(defn can-vote
  [age]
  (if (>= age 18)  ;; jezeli age >= 18
    (println "You can vote")  ;; wykonaj, jezeli warunek prawdziwy
    (println "You can't vote")  ;; wykonaj, jezeli warunek falszywy
    ))


(defn can-do-more 
  [age]
  (if (>= age 18)
    (do (println "You can drive")
        (println "You can vote"))
    (println "You can't vote")))


;; jezeli prawdziwe, wykonaj wszystkie instrukcje, jezeli nie, to nic nie wykonuj
(defn when-ex
  [tof]
  (when tof
    (println "1st thing")
    (println "2nd thing")))


;; cond - wiele warunków jakby switch
(defn what-grade
  [n]
  (cond
    (< n 5) (println "Preschool")
    (= n 5) (println "Kindergarten")
    (and (> n 5) (<= n 18)) (format "Go to grade %d"
                            (- n 5))
    :else "Go to Collage"))




; --- ---[ Loops ]--- --- 

(defn one-to-x
   [x]
   (def i (atom 1)) ;; przypisujemy do zmiennej i atom o wartosci 1
   (while (<= @i x)
     (do
       (println @i)
       (swap! i inc))))  ;; zamien wartosc i na i+1

(one-to-x 15)


;; dotimes jest odpowiednikiem petli for 
(defn dbl-to-x
  [x]
  (dotimes [i x]  ;; od 0 do x niewlacznie
    (println (* i 2))))

(dbl-to-x 8)


;; petla for, ale zaczynamy od liczby wybranej przez nas
(defn triple-to-x
  [x y]
  (loop [i x]
    (when (< i y)
      (println (* i 3))

      (recur (+ i 2))))) ;; w kolejnym wykonaniu nasza zmianna i bedzie wieksza o 2

(triple-to-x 5 12) ; i =   5 => 7 => 9  => 11 => stop petli
      


;; wykorzystywane do iteracji sekwencji
;; jest to odpowiednik pętli foreach
(defn print-list
  [& nums]  ;; lista w parametrze funkcji
  (doseq [x nums] ;; sekwencja dla kazdego elementu funkcji 
    (println x))) 

(print-list 7 8 9)



; --- ---[ Anonymous Functions (funkcje bez nazw) ]--- --- 

(map (fn [x] (* x x)) (range 1 10)) ;; funkcja z arugmentem x, ktora mapujemy w zakresie 1-10

;; kompaktowa funkcja anonimowa #, gdzie % to jej parametr
(map #(* % 3) (range 1 10))

;; kompaktowa anonimowa z kilkoma parametrami
(#(* %1 %2) 2 3)




; --- ---[ Filtering Lists ]--- --- 

(take 2 [1 2 3 4]) ;; zwroc dwie pierwsze wartosci z tablicy
(drop 1 [1 2 3]) ;; wykasuj pierwszy element z tablicy
(take-while neg? [-1 0 1]) ;; wyfiltruj wylacznie wartosci o podanym warunku
(drop-while neg? [-1 0 1]) ;; wykasuj wartosci o podanym warunku
(filter #(> % 2) [1 2 3 4]) ;; wyfiltruj wartosci o podanym warunku - wykorzystujemy do tego funkcje anonimowa





