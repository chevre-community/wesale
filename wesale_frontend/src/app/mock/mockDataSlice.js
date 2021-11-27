import { createSlice } from "@reduxjs/toolkit";
import { HYDRATE } from "next-redux-wrapper";

const initialState = {
	announcements: [
		{
			id: 0,
			price: 1200,
			images: [
				"https://media.istockphoto.com/photos/digitally-rendered-view-of-a-beautiful-living-room-picture-id1284941025?b=1&k=20&m=1284941025&s=170667a&w=0&h=JfkOADW4trv6oQWATk6nuDQdBTEQig3c_u03pwM58PI=",
				"https://media.istockphoto.com/photos/luxury-great-room-with-lots-of-glass-windows-picture-id1320898410?b=1&k=20&m=1320898410&s=170667a&w=0&h=zPzrpICSfE0-3WzjS2Dgh5_skyb9CA8X-vzU6yTTOgs=",
				"https://images.unsplash.com/photo-1591088398332-8a7791972843?ixid=MnwxMjA3fDB8MHxzZWFyY2h8NHx8aG9tZSUyMGRlc2lnbnxlbnwwfHwwfHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=600&q=60",
				"https://images.unsplash.com/photo-1618221195710-dd6b41faaea6?ixid=MnwxMjA3fDB8MHxzZWFyY2h8NHx8aG9tZSUyMGRlY29yYXRpb258ZW58MHx8MHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=600&q=60",
				"https://images.unsplash.com/photo-1616486029423-aaa4789e8c9a?ixid=MnwxMjA3fDB8MHxzZWFyY2h8OXx8aG9tZSUyMGRlY29yYXRpb258ZW58MHx8MHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=600&q=60",
			],
			currency: "$",
			rooms: 3,
			area: 220,
			floor: "14/17",
			address: "Квартира, метро Н.Нариманов",
		},
		{
			id: 1,
			price: 1900,
			images: [
				"https://media.istockphoto.com/photos/paintig-an-old-furniture-at-home-picture-id1279269349?b=1&k=20&m=1279269349&s=170667a&w=0&h=MaLVvXtDZQqSS78IXUEk5DVzOQ4wlY7kyMdRZfoS4GM=",
				"https://images.unsplash.com/photo-1618220048045-10a6dbdf83e0?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8M3x8aG9tZSUyMGRlY29yYXRpb258ZW58MHx8MHx8&auto=format&fit=crop&w=600&q=60",
				"https://images.unsplash.com/photo-1591088398332-8a7791972843?ixid=MnwxMjA3fDB8MHxzZWFyY2h8NHx8aG9tZSUyMGRlc2lnbnxlbnwwfHwwfHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=600&q=60",
				"https://images.unsplash.com/photo-1618221195710-dd6b41faaea6?ixid=MnwxMjA3fDB8MHxzZWFyY2h8NHx8aG9tZSUyMGRlY29yYXRpb258ZW58MHx8MHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=600&q=60",
				"https://images.unsplash.com/photo-1616486029423-aaa4789e8c9a?ixid=MnwxMjA3fDB8MHxzZWFyY2h8OXx8aG9tZSUyMGRlY29yYXRpb258ZW58MHx8MHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=600&q=60",
			],
			currency: "$",
			rooms: 4,
			area: 320,
			floor: "4/17",
			address: "Квартира, метро Ganjlik",
		},
		{
			id: 2,
			price: 900,
			images: [
				"https://media.istockphoto.com/photos/apartment-kitchen-in-modern-rustic-style-picture-id1261144904?b=1&k=20&m=1261144904&s=170667a&w=0&h=-zGXW8T8NKbyKcrQ5Ty1M3nHxoB-NY9ZsIX_sHcC230=",
				"https://media.istockphoto.com/photos/paintig-an-old-furniture-at-home-picture-id1279269349?b=1&k=20&m=1279269349&s=170667a&w=0&h=MaLVvXtDZQqSS78IXUEk5DVzOQ4wlY7kyMdRZfoS4GM=",
				"https://images.unsplash.com/photo-1618220048045-10a6dbdf83e0?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8M3x8aG9tZSUyMGRlY29yYXRpb258ZW58MHx8MHx8&auto=format&fit=crop&w=600&q=60",
				"https://images.unsplash.com/photo-1591088398332-8a7791972843?ixid=MnwxMjA3fDB8MHxzZWFyY2h8NHx8aG9tZSUyMGRlc2lnbnxlbnwwfHwwfHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=600&q=60",
				"https://images.unsplash.com/photo-1618221195710-dd6b41faaea6?ixid=MnwxMjA3fDB8MHxzZWFyY2h8NHx8aG9tZSUyMGRlY29yYXRpb258ZW58MHx8MHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=600&q=60",
				"https://images.unsplash.com/photo-1616486029423-aaa4789e8c9a?ixid=MnwxMjA3fDB8MHxzZWFyY2h8OXx8aG9tZSUyMGRlY29yYXRpb258ZW58MHx8MHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=600&q=60",
			],
			currency: "$",
			rooms: 2,
			area: 65,
			floor: "2/5",
			address: "Квартира, метро Nizami",
		},
		{
			id: 3,
			price: 27500,
			images: [
				"https://media.istockphoto.com/photos/beautifully-christmas-decorated-home-interior-with-a-christmas-tree-picture-id1277659182?b=1&k=20&m=1277659182&s=170667a&w=0&h=lsF4yWlZaqCjydOo-4VaAhdgAE41VnG21pzUElC2m-s=",
				"https://media.istockphoto.com/photos/apartment-kitchen-in-modern-rustic-style-picture-id1261144904?b=1&k=20&m=1261144904&s=170667a&w=0&h=-zGXW8T8NKbyKcrQ5Ty1M3nHxoB-NY9ZsIX_sHcC230=",
				"https://media.istockphoto.com/photos/paintig-an-old-furniture-at-home-picture-id1279269349?b=1&k=20&m=1279269349&s=170667a&w=0&h=MaLVvXtDZQqSS78IXUEk5DVzOQ4wlY7kyMdRZfoS4GM=",
				"https://images.unsplash.com/photo-1591088398332-8a7791972843?ixid=MnwxMjA3fDB8MHxzZWFyY2h8NHx8aG9tZSUyMGRlc2lnbnxlbnwwfHwwfHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=600&q=60",
				"https://images.unsplash.com/photo-1618221195710-dd6b41faaea6?ixid=MnwxMjA3fDB8MHxzZWFyY2h8NHx8aG9tZSUyMGRlY29yYXRpb258ZW58MHx8MHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=600&q=60",
				"https://images.unsplash.com/photo-1616486029423-aaa4789e8c9a?ixid=MnwxMjA3fDB8MHxzZWFyY2h8OXx8aG9tZSUyMGRlY29yYXRpb258ZW58MHx8MHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=600&q=60",
			],
			currency: "$",
			rooms: 5,
			area: 145,
			floor: "12/15",
			address: "Квартира, метро Hazi Aslanov",
		},
		{
			id: 4,
			price: 7500,
			images: [
				"https://images.unsplash.com/photo-1618219740975-d40978bb7378?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8MjJ8fGhvbWUlMjBkZWNvcmF0aW9ufGVufDB8fDB8fA%3D%3D&auto=format&fit=crop&w=600&q=60",
				"https://media.istockphoto.com/photos/apartment-kitchen-in-modern-rustic-style-picture-id1261144904?b=1&k=20&m=1261144904&s=170667a&w=0&h=-zGXW8T8NKbyKcrQ5Ty1M3nHxoB-NY9ZsIX_sHcC230=",
				"https://media.istockphoto.com/photos/paintig-an-old-furniture-at-home-picture-id1279269349?b=1&k=20&m=1279269349&s=170667a&w=0&h=MaLVvXtDZQqSS78IXUEk5DVzOQ4wlY7kyMdRZfoS4GM=",
				"https://images.unsplash.com/photo-1616486029423-aaa4789e8c9a?ixid=MnwxMjA3fDB8MHxzZWFyY2h8OXx8aG9tZSUyMGRlY29yYXRpb258ZW58MHx8MHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=600&q=60",
			],
			currency: "$",
			rooms: 4,
			area: 145,
			floor: "6/15",
			address: "Квартира, метро Hazi Aslanov",
		},
		{
			id: 5,
			price: 27500,
			images: [
				"https://images.unsplash.com/photo-1618221710640-c0eaaa2adb49?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mjd8fGhvbWUlMjBkZWNvcmF0aW9ufGVufDB8fDB8fA%3D%3D&auto=format&fit=crop&w=600&q=60",
				"https://media.istockphoto.com/photos/apartment-kitchen-in-modern-rustic-style-picture-id1261144904?b=1&k=20&m=1261144904&s=170667a&w=0&h=-zGXW8T8NKbyKcrQ5Ty1M3nHxoB-NY9ZsIX_sHcC230=",
				"https://media.istockphoto.com/photos/paintig-an-old-furniture-at-home-picture-id1279269349?b=1&k=20&m=1279269349&s=170667a&w=0&h=MaLVvXtDZQqSS78IXUEk5DVzOQ4wlY7kyMdRZfoS4GM=",
				"https://images.unsplash.com/photo-1618221195710-dd6b41faaea6?ixid=MnwxMjA3fDB8MHxzZWFyY2h8NHx8aG9tZSUyMGRlY29yYXRpb258ZW58MHx8MHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=600&q=60",
				"https://images.unsplash.com/photo-1616486029423-aaa4789e8c9a?ixid=MnwxMjA3fDB8MHxzZWFyY2h8OXx8aG9tZSUyMGRlY29yYXRpb258ZW58MHx8MHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=600&q=60",
			],
			currency: "$",
			rooms: 52,
			area: 145,
			floor: "12/15",
			address: "Квартира, метро Hazi Aslanov",
		},
		{
			id: 6,
			price: 27500,
			images: [
				"https://images.unsplash.com/photo-1613545564241-296299063513?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8MzR8fGhvbWUlMjBkZWNvcmF0aW9ufGVufDB8fDB8fA%3D%3D&auto=format&fit=crop&w=600&q=60",
				"https://media.istockphoto.com/photos/apartment-kitchen-in-modern-rustic-style-picture-id1261144904?b=1&k=20&m=1261144904&s=170667a&w=0&h=-zGXW8T8NKbyKcrQ5Ty1M3nHxoB-NY9ZsIX_sHcC230=",
				"https://media.istockphoto.com/photos/paintig-an-old-furniture-at-home-picture-id1279269349?b=1&k=20&m=1279269349&s=170667a&w=0&h=MaLVvXtDZQqSS78IXUEk5DVzOQ4wlY7kyMdRZfoS4GM=",
				"https://images.unsplash.com/photo-1616486029423-aaa4789e8c9a?ixid=MnwxMjA3fDB8MHxzZWFyY2h8OXx8aG9tZSUyMGRlY29yYXRpb258ZW58MHx8MHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=600&q=60",
			],
			currency: "$",
			rooms: 52,
			area: 145,
			floor: "12/15",
			address: "Квартира, метро Hazi Aslanov",
		},
		{
			id: 6,
			price: 27500,
			images: [
				"https://images.unsplash.com/photo-1618296498428-475b880e5b0a?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NDF8fGhvbWUlMjBkZWNvcmF0aW9ufGVufDB8fDB8fA%3D%3D&auto=format&fit=crop&w=600&q=60",
				"https://images.unsplash.com/photo-1613545564241-296299063513?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8MzR8fGhvbWUlMjBkZWNvcmF0aW9ufGVufDB8fDB8fA%3D%3D&auto=format&fit=crop&w=600&q=60",
				"https://media.istockphoto.com/photos/apartment-kitchen-in-modern-rustic-style-picture-id1261144904?b=1&k=20&m=1261144904&s=170667a&w=0&h=-zGXW8T8NKbyKcrQ5Ty1M3nHxoB-NY9ZsIX_sHcC230=",
				"https://images.unsplash.com/photo-1616486029423-aaa4789e8c9a?ixid=MnwxMjA3fDB8MHxzZWFyY2h8OXx8aG9tZSUyMGRlY29yYXRpb258ZW58MHx8MHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=600&q=60",
			],
			currency: "$",
			rooms: 52,
			area: 145,
			floor: "12/15",
			address: "Квартира, метро Hazi Aslanov",
		},
	],
};

const mockDataSlice = createSlice({
	name: "mockData",
	initialState,
	reducers: {},
	extraReducers: {
		[HYDRATE]: (state, { payload }) => ({
			...state,
			...payload.mockData,
		}),
	},
});

export default mockDataSlice.reducer;

export const selectAnnouncements = (state) => state.mockData.announcements;
