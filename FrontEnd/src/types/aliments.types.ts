interface SingleComponent {
  singleComponentId: string;
  alimentId: string;
  componente: string;
  unidades: string;
  valorPor100g: string;
  desvioPadrão: string;
  valorMínimo: string;
  valorMáximo: string;
  númeroDeDadosUtilizado: string;
  referências: string;
  tipoDeDados: string;
}

interface Aliment {
  alimentId: string;
  name: string;
  scientificName: string;
  group: string;
  brand: string;
  components: SingleComponent[];
}

export type { Aliment, SingleComponent };