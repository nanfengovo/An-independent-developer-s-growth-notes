export interface buttonStyleModel {
    BordersStyle: string;
    Size: string;
    Types: string;
    Icon: string;
    ButtonStyleName: string;
    Borders: string;
    Radius: Number | undefined;
    IsRadius:boolean;
    ButtonStyleId:Number;
}

export interface buttonModel {
    BordersStyle: string;
    Size: string;
    Types: string;
    Icon: string;
    ButtonStyleName: string;
    Borders: string;
    Radius: Number | undefined;
    IsRadius:boolean;
    ButtonStyleId:Number | undefined;
    MenuId:Number | undefined;
    ButtonName:string;
    ButtonKey:string;
    OrderBy:Number ;
    ButtonId:Number ;
}

export const bordersStyleList = [
   
    {
        key: 'soild',
        value: '实线'
    },
    // {
    //     key: 'dotted',
    //     value: '点线'
    // }
    // ,
    {
        key: 'dashed',
        value: '虚线'
    }
]

export const sizeList = [
    {
        key: 'lg',
        value: '大'
    },
    {
        key: 'md',
        value: '较大'
    },
    {
        key: 'sm',
        value: '中'
    },
    {
        key: 'xs',
        value: '小'
    }
]

export const typesList = [
    {
        key: '',
        value: '默认按钮'
    },
    {
        key: 'primary',
        value: '原始按钮'
    },
    {
        key: 'normal',
        value: '百搭按钮'
    },
    {
        key: 'warm',
        value: '暖色按钮'
    },
    {
        key: 'danger',
        value: '警告按钮'
    },
    // {
    //     key: 'purple',
    //     value: '紫色按钮'
    // }
]

export const bordersList = [
    {
        key: '',
        value: '无'
    },
    {
        key: 'green',
        value: '绿色边框'
    },
    {
        key: 'blue',
        value: '蓝色边框'
    },
    {
        key: 'orange',
        value: '橙色边框'
    },
    {
        key: 'red',
        value: '红色边框'
    },
    // {
    //     key: 'purple',
    //     value: '紫色按钮'
    // }
]