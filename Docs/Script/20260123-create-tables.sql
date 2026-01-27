-- Incidentes definition

CREATE TABLE Incidentes (
                        Id INTEGER PRIMARY KEY,
                        Number TEXT NOT NULL,
                        AssignmentGroup TEXT,
                        State TEXT,
                        Caller TEXT,
                        AssignedTo TEXT,
                        Priority TEXT,
                        Created TEXT,
                        ShortDescription TEXT,
                        ConfigurationItem TEXT,
                        Email TEXT
                    ) STRICT;

-- StatusInternos definition

CREATE TABLE StatusInternos (
    NumeroIncidente TEXT PRIMARY KEY, -- Agora o número é a chave primária
    StatusInterno TEXT NOT NULL,
    Observacao TEXT,
    DataAtualizacao TEXT DEFAULT (datetime('now', 'localtime'))
) STRICT;