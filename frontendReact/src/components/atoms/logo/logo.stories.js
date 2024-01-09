import React from 'react';
import LogoAtom from './LogoAtom';

export default {
  title: 'ATOMS/LogoAtom',
  component: LogoAtom,
  argTypes: {
    alt: { control: 'text' }, // Voeg dit toe om de alt-tekst aan te passen
  },
};

const Template = (args) => <LogoAtom {...args} />;

export const Default = {
  args: {
    alt: 'Happy Paw Logo', // Geef een standaardwaarde voor de alt-tekst
  },
};