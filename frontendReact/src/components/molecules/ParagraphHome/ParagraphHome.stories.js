import React from 'react';
import ParagraphMolecule from './ParagraphHome';

export default {
  title: 'MOLECULES/ParagraphMolecule',
  component: ParagraphMolecule,
  argTypes: {
    content1: { control: 'text' },
    content2: { control: 'text' },
    size1: { control: 'select', options: ['small', 'medium', 'large'] },
    size2: { control: 'select', options: ['small', 'medium', 'large'] },
  },
};

const Template = (args) => <ParagraphMolecule {...args} />;

export const Default = Template.bind({});
Default.args = {
  content1: 'First paragraph content',
  content2: 'Second paragraph content',
  size1: 'medium',
  size2: 'small',
};