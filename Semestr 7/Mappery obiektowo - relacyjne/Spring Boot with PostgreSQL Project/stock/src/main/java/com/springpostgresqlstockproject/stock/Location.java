package com.springpostgresqlstockproject.stock;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@AllArgsConstructor
@NoArgsConstructor
@Entity
@Table(name = "location")
public class Location {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;

    @Column(name = "loc_row", nullable = false)
    private Integer locRow; 

    @Column(name = "loc_column", nullable = false)
    private Integer locColumn; 

    @Column(name = "loc_shelf", nullable = false)
    private Integer locShelf; 
}
