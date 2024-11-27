https://www.bilibili.com/video/BV1owSMY7Ek4?spm_id_from=333.788.videopod.episodes&vd_source=b7200d0eaee914e9c128dcabce5df118&p=6 

# 模板语法
## 文本插值
	<span>Message:{{msg}}</span>
## 插入HTML
	 <script setup>
	 const xd = "<span style = ‘color:red’>小滴课堂</span>;"
	 </scropt>
	 
	 <template>
		<div v-html="xd"></div>
	</template>
# Attribute 绑定
## v-bind 指令
	 <script setup>
	 const xd = "小滴课堂;"
	 </scropt>
	 
	 <template>
		<div v-bind:id="xd"></div>      --这里v-bind可以省略
	</template>