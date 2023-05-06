(ns first-app.Zadanie1)

(defn Zad1
  [x]
  (- 
   (Math/pow (apply + (for [i (range x)] (inc i))) 2)
  (apply + (for [i (range x)] (Math/pow (inc i) 2)))))

(Zad1 10)





;; Funkcja tworzy wektor od 1 do n
(defn create-array 
  [n]
  (vec (range 1 (inc n))))

(def v1 (create-array 10))

(println v1)








(sum 
 (doseq [e v1] (* e e)))









;; zrobic to na doseq

;; (def v1 [1 2 3])
;; (doseq [e v1] (println e))

;; (map str v1)

;; (for [e v1] (println e))


;; ;; iloczyn kartezjanski

;; ;; (for [e1 v1, e2 v1] (map e1 e2))

;; (for [e1 v1, e2 v2] (vector e1 e2))

;; (into {})


;; (map vector v1 v2)


