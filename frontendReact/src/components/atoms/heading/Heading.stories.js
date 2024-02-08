import Heading from "./Heading";

export default {
    title: 'ATOMS/Heading',
    component: Heading,
    argTypes: {
        level: {
          control: {
            type: 'select',
            options: [1, 2, 3, 4, 5, 6],
          },
        },
        text: { control: 'text' },
        className: { control: 'text' },
      },
    };

const Template = (args) => <Heading {...args} />

export const Default = Template.bind({})
Default.args = {
    level: 1,
    text: 'Heading 1',
}