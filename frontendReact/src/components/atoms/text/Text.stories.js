import React from 'react';
import Text from './Text';

export default {
  title: 'ATOMS/Text',
  component: Text,
  argTypes: {
    content: { control: 'text' },
    size: { control: 'text' },
    color: { control: 'color' },
    bold: { control: 'boolean' },
    italic: { control: 'boolean' },
    underline: { control: 'boolean' },
  },
};

const Template = (args) => <Text {...args} />;

export const Default = Template.bind({});
Default.args = {
  content: 'Hello, Storybook!',
  size: '16px',
  color: '#333',
  bold: false,
  italic: false,
  underline: false,
};