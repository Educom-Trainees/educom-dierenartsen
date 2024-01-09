import React from 'react';
import IntroText from './IntroText';

export default {
  title: 'ATOMS/IntroText',
  component: IntroText,
  argTypes: {
    text: { control: 'text' },
  },
};

const Template = (args) => <IntroText {...args} />;

export const Default = {
  args: {
    text: 'Waar liefde en zorg samenkomen voor de gezondheid en vreugde van uw trouwe Huisdier.',
  },
};