import { createTheme } from '@mantine/core';

export const theme = createTheme({
  /** Put your mantine theme override here */
  fontFamily: 'Inter, sans-serif',
  fontFamilyMonospace: 'Monaco, Courier, monospace',
  headings: { fontFamily: 'Inter, sans-serif' },
  colors: {
    deepBlue: [
      '#e0e8f9',
      '#b3c6f2',
      '#87a4eb',
      '#5b82e4',
      '#3362dd',
      '#1a49d6',
      '#0f39c2',
      '#0a2ba3',
      '#061e85',
      '#031266',
    ],
    myCustomGreen: [
      '#e8f5e9',
      '#c8e6c9',
      '#a5d6a7',
      '#81c784',
      '#66bb6a',
      '#4caf50',
      '#43a047',
      '#388e3c',
      '#2e7d32',
      '#1b5e20',
    ],
  },
  primaryColor: 'pink',
});
