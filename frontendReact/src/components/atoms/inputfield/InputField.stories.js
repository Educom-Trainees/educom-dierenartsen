import React from 'react';
import Input from './InputField';

export default {
  title: 'ATOMS/InputField',
  component: Input,
  argTypes: {
    type: { control: 'text' },
    placeholder: { control: 'text' },
    value: { control: 'text' },
  },
};

const Template = (args) => <Input {...args} />;

export const Default = Template.bind({});
Default.args = {
  type: 'text',
  placeholder: 'Type something...',
  value: '',
};