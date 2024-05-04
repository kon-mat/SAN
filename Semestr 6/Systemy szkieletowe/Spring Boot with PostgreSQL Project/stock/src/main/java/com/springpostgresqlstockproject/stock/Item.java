package com.springpostgresqlstockproject.stock;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data   // Lobok - generuje boilerplate (@ToString, @EqualsAndHashCode, @Getter / @Setter i @RequiredArgsConstructor)
@AllArgsConstructor // Lombok - generuje konstruktor z 1 parametrem dla każdego pola w klasie
@NoArgsConstructor  // Lombok - generuje konstruktor bez parametrów
public class Item {
    private int id;
    private String ean;
    private String brand;
    private String size;
    private String color;
    private int locationId;
}
