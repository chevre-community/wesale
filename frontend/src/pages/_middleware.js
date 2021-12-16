import { NextRequest, NextResponse } from "next/server";

export const middleware = (req) => {
	const { token } = req.cookies;

	// if (!token) {
	// 	if (req.url === "/home") {
	// 		return NextResponse.redirect("/dashboard");
	// 	}
	// }
};
