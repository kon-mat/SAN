package com.springpostgresqlstockproject.stock;

import jakarta.persistence.*; // Adnotacje JPA
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@AllArgsConstructor
@NoArgsConstructor
@Entity // Oznacza klasę jako encję JPA, co pozwala Hibernate mapować ją na tabelę w bazie danych
@Table(name = "item") // Mapowanie klasy na tabelę o nazwie "item"
public class Item {

    @Id // Oznacza pole jako klucz główny
    @GeneratedValue(strategy = GenerationType.IDENTITY) // Automatyczne generowanie wartości klucza głównego
    private Long id; // Typ Long jest zalecany dla kluczy głównych w JPA

    @Column(nullable = false)
    private String ean;

    @Column(nullable = false)
    private String brand;

    private String size;

    private String color;

    @Column(name = "location_id", nullable = false) // Mapowanie na kolumnę "location_id" w tabeli
    private int locationId;
}
