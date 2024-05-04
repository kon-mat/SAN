package com.springpostgresqlstockproject.stock;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class Location {
    private int id;
    private int loc_row;
    private int loc_column;
    private int loc_shelf;
}
